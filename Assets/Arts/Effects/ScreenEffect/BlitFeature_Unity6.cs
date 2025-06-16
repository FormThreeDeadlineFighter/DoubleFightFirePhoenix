using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlitFeature_Unity6 : ScriptableRendererFeature
{
    [System.Serializable]
    public class BlitSettings
    {
        public RenderPassEvent Event = RenderPassEvent.AfterRenderingOpaques;
        public Material blitMaterial;
        public int passIndex = 0;
    }

    public BlitSettings settings = new BlitSettings();
    BlitPass blitPass;

    public override void Create()
    {
        blitPass = new BlitPass(settings.Event, settings.blitMaterial, settings.passIndex);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (settings.blitMaterial == null)
        {
            Debug.LogWarning("Missing Blit Material");
            return;
        }

        blitPass.Setup(renderer.cameraColorTargetHandle);
        renderer.EnqueuePass(blitPass);
    }

    class BlitPass : ScriptableRenderPass
    {
        Material blitMaterial;
        int passIndex;
        RTHandle source;

        string profilerTag = "Custom Blit Pass";

        public BlitPass(RenderPassEvent renderPassEvent, Material material, int passIndex)
        {
            this.renderPassEvent = renderPassEvent;
            this.blitMaterial = material;
            this.passIndex = passIndex;
        }

        public void Setup(RTHandle source)
        {
            this.source = source;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cmd = CommandBufferPool.Get(profilerTag);

            // cameraTargetDescriptor 會帶入 RT 的解析度、HDR 等設定
            var descriptor = renderingData.cameraData.cameraTargetDescriptor;
            descriptor.depthBufferBits = 0;

            // 建立一個暫存 RTHandle
            RTHandle temp = RTHandles.Alloc(descriptor, name: "_TempBlit");

            // 第一次 Blit 到 temp
            Blit(cmd, source, temp, blitMaterial, passIndex);
            // 再從 temp Blit 回 source
            Blit(cmd, temp, source);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
            temp.Release();
        }
    }
}
