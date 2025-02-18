using UnityEngine;

public class PlayerState_Move : IPlayerState
{
    public PlayerState_Move(PlayerStateController Controller) : base(Controller)
    {

    }

    public override void EnterState() { }

    public override void ExitState() { }

    public  override void LogicUpdate() { }

    public override void PhysicsUpdate() { }
}
