using UnityEngine;

public class StartState : ISceneState
{
    public StartState(SceneStateController Controller) : base (Controller)
    {
        this.StateName = "StartState";
    }

    //開始
    public override void StateBegin()
    {
        
    }

    //更新
    public override void StateUpdate()
    {
        //_Controller.SetState(new MainMenuState(_Controller),"MainMenuState");
    }
}
