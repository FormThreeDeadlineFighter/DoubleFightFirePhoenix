using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : IPlayerState
{
    [SerializeField] float _forwardSpeed;

    public override void EnterState()
    {
        Debug.Log(_controller.PlayerName +"進入待機狀態");
    }

    public override void ExitState()
    {
        Debug.Log(_controller.PlayerName +"離開待機狀態");
    }

    public override void LogicUpdate()
    {
        //Debug.Log("玩家在閒置狀態");
        if(_shipController.IsMove(_controller.PlayerName))
        {
            _controller.SetState(typeof(PlayerState_Move));
        }

        if(_shipController.IsImpulse(_controller.PlayerName))  
        {
            _controller.SetState(typeof(PlayerState_Impulse));
        }  
    }

    public override void PhysicsUpdate()
    {
        // 物理相關的更新（如果有的話）
        if(_shipController.IsShoot(_controller.PlayerName))
        {
            _shipController.Shoot();
        }

        _shipController.Forward(_forwardSpeed);
    }
}
