using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Move", fileName = "PlayerState_Move")]
public class PlayerState_Move : IPlayerState
{
    public override void EnterState()
    {
        Debug.Log("玩家進入移動狀態");
    }

    public override void ExitState()
    {
        Debug.Log("玩家離開移動狀態");
    }

    public override void LogicUpdate()
    {
        if(Keyboard.current.sKey.isPressed)
        {
            _controller.SwitchState(typeof(PlayerState_Move));
        }       
    }

    public override void PhysicsUpdate()
    {
        
    }
}
