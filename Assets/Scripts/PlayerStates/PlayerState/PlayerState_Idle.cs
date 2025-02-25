using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : IPlayerState
{
    [SerializeField] float moveSpeed;

    public override void EnterState()
    {
        Debug.Log("玩家進入待機狀態");
    }

    public override void ExitState()
    {
        Debug.Log("玩家離開待機狀態");
    }

    public override void LogicUpdate()
    {
        //Debug.Log("玩家在閒置狀態");
        if(_shipController.Move)
        {
            _controller.SetState(typeof(PlayerState_Move));
        }

        if(_shipController.IsImpulse)  
        {
            _controller.SetState(typeof(PlayerState_Impulse));
        }  
    }

    public override void PhysicsUpdate()
    {
        // 物理相關的更新（如果有的話）
        if(_shipController.IsShoot)
        {
            _shipController.Shoot();
        }

        _shipController.Forward(moveSpeed);
    }
}
