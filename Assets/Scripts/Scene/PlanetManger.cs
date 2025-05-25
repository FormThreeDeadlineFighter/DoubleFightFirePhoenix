using UnityEngine;

public class PlanetManger : MonoBehaviour
{
    public GameObject[] Planet;
    public GameObject[] Stage;
    public Canvas uiCanvas;
    GameObject currentModel;
    GameObject currentStage;
    int currentIndex = 0;
    void Start()
    {
        ShowModel(currentIndex);
        ShowStageButton(currentIndex);
    }
    void ShowModel(int index)
    {
        currentModel = Instantiate(Planet[index]);
    }
    void ShowStageButton(int index)
    {
        currentStage = Instantiate(Stage[index], uiCanvas.transform);
    }
    public void RightButton()
    {
        Destroy(currentModel);
        Destroy(currentStage);
        currentIndex++;
        if (currentIndex >= Planet.Length)
        {
            currentIndex = 0;
        }
        ShowModel(currentIndex);
        ShowStageButton(currentIndex);
    }
    public void LeftButton()
    {
        Destroy(currentModel);
        Destroy(currentStage);
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = Planet.Length-1;
        }
        ShowModel(currentIndex);
        ShowStageButton(currentIndex);
    }
}
