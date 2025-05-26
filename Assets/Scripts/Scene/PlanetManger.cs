using UnityEngine;
using System.Collections;

public class PlanetManger : MonoBehaviour
{
    public GameObject[] Stage;
    public GameObject SpaceCenter;
    public Canvas uiCanvas;
    int[] planet = new int[] { 0,90,180,270};
    GameObject currentStage;
    int currentIndex = 0;
    void Start()
    {
        ShowStageButton(currentIndex);
    }
    void ShowStageButton(int index)
    {
        currentStage = Instantiate(Stage[index], uiCanvas.transform);
    }
    public void RightButton()
    {
        Destroy(currentStage);
        currentIndex++;
        if (currentIndex == Stage.Length)
        {
            currentIndex = 0;
        }
        StartCoroutine(PlanetMove(currentIndex));
        ShowStageButton(currentIndex);
    }
    public void LeftButton()
    {
        Destroy(currentStage);
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = Stage.Length - 1;
        }
        StartCoroutine(PlanetMove(currentIndex));
        ShowStageButton(currentIndex);
    }
    IEnumerator PlanetMove(int index)
    {
        Quaternion startRot = SpaceCenter.transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0, planet[index], 0);

        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            // 平滑插值
            SpaceCenter.transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        // 最後保證精準到達目標角度
        SpaceCenter.transform.rotation = targetRot;
    }
    
}
