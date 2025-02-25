using UnityEngine;

public interface IState_weapon 
{
    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }
}
