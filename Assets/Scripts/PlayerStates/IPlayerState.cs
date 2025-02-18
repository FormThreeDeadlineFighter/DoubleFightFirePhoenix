using UnityEngine;
using UnityEngine.InputSystem;

public interface  IPlayerState 
{ 
    bool IsComplete {get; }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }


}
