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
        //Debug.Log("玩家在移動狀態");
        if(!Keyboard.current.wKey.isPressed)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }       
    }

    public override void PhysicsUpdate()
    {
        
    }
}
