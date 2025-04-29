using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{   
    private Button Start;
    public MainMenuState(SceneStateController Controller) : base (Controller)
    {
        this.StateName = "MainMenuState";
    }
    //開始
    public override void StateBegin()
    {
        //取得開始按鈕
        GameObject startObj = GameObject.Find("StartButton");

        if (startObj != null)
        {
            Debug.Log("找到 StartButton !");
            Start = startObj.GetComponent<Button>();
            Start.onClick.AddListener(OnStartButtonClick);
        }
        else
        {
            Debug.LogError("找不到 StartButton !");
        }
    }
    private void OnStartButtonClick()
    {
        Debug.Log("Start Button 被按下！");
        // 這邊可以接關卡切換或其他功能
        _Controller.SetState(new StageMapState(_Controller),"StageMapState");
    }
    public override void StateEnd()
    {
        
    }

}
