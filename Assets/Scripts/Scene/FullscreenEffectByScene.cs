using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class FullscreenEffectByScene : MonoBehaviour
{
    [Tooltip("指定要開啟 Fullscreen Effect 的場景名稱")]
    public string[] enabledScenes;

    [Tooltip("Renderer 資源（ForwardRenderer.asset）")]
    public UniversalRendererData rendererData;

    [Tooltip("Feature 名稱，與 Inspector 上名字一樣")]
    public string featureName = "FullScreenPass Renderer Feature";

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        bool shouldEnable = false;
        foreach (string scene in enabledScenes)
        {
            if (scene == currentScene)
            {
                shouldEnable = true;
                break;
            }
        }

        foreach (var feature in rendererData.rendererFeatures)
        {
            if (feature != null && feature.name == featureName)
            {
                feature.SetActive(shouldEnable);
                break;
            }
        }
    }
}
