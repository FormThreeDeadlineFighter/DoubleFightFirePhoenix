using UnityEngine;

public abstract class IPlayerState 
{ 
    public bool _isComplete {get; protected set;}

    protected float _startTime;

    public float _time => Time.time - _startTime;

    protected PlayerStateController _Controller = null;

    public IPlayerState(PlayerStateController Controller)
    {
        _Controller = Controller;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }


}
