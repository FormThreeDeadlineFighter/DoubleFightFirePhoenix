using UnityEngine;
using UnityEngine.UI;
public class StageMapState : ISceneState
{
    public StageMapState(SceneStateController Controller) : base (Controller)
    {
        this.StateName = "StageMapState";
    }
    public override void StateBegin()
    {
        GameObject[] allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (var obj in allObjects)
        {
        Debug.Log("場景中的物件：" + obj.name);
        }
        
        BindButton("Stage1Button", () => OnStageButtonClick(1));
        BindButton("Stage2Button", () => OnStageButtonClick(2));
        BindButton("Stage3Button", () => OnStageButtonClick(3));
        BindButton("Stage4Button", () => OnStageButtonClick(4));
        BindButton("Stage5Button", () => OnStageButtonClick(5));
    }
    private void OnStageButtonClick(int stageNumber)
    {
        Debug.Log($"點擊了第 {stageNumber} 關！");
        // 你可以根據 stageNumber 載入對應關卡：
        string stageSceneName = $"Level-{stageNumber}";
        _Controller.SetState(new GamePlayState(_Controller), stageSceneName);
    }
    
}
