using UnityEngine;

public class GamePlayState : ISceneState
{
    public GamePlayState(SceneStateController controller) : base(controller)
    {
        this.StateName = "GamePlayState";
    }
    public override void StateBegin()
    {
        Debug.Log("進入遊戲關卡！");
    }

    public override void StateUpdate()
    {
        // 遊戲中更新邏輯
    }
}
