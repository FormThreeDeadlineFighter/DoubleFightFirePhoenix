using UnityEngine;

public class ISceneState
{
    //狀態名稱
    private string _StateName = "ISceneState";
    public string StateName
    {
        get {return _StateName;}
        set {_StateName = value;}
    }

    //控制者
    protected SceneStateController _Controller = null;

    //建構者
    public ISceneState (SceneStateController Controller)
    {
        _Controller = Controller;
    }

    //開始
    public virtual void StateBegin()
    {}

    //結束
    public virtual void StateEnd()
    {}

    //更新
    public virtual void StateUpdate()
    {}

    public override string ToString()
    {
        return string.Format("[I_SceneState: StateName = {0}]",StateName);
    }
}
