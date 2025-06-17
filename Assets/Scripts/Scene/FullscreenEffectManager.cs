using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class FullscreenEffectManager : MonoBehaviour
{
    [System.Serializable]
    public class EffectSetting
    {
        public UniversalRendererData rendererData;
        public string featureName;
        public string[] enabledScenes;
    }

    public EffectSetting[] effects;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // 讓它跨場景保留
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentScene = scene.name;

        foreach (var effect in effects)
        {
            bool shouldEnable = false;

            foreach (string s in effect.enabledScenes)
            {
                if (s == currentScene)
                {
                    shouldEnable = true;
                    break;
                }
            }

            foreach (var feature in effect.rendererData.rendererFeatures)
            {
                if (feature != null && feature.name == effect.featureName)
                {
                    feature.SetActive(shouldEnable);
                    Debug.Log($"[Effect] {feature.name} => {(shouldEnable ? "開啟" : "關閉")} @ {currentScene}");
                    break;
                }
            }
        }
    }
}
