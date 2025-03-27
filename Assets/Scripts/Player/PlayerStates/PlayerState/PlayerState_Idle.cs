using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : IPlayerState
{
    [SerializeField] float _forwardSpeed;

    public override void EnterState()
    {
        Debug.Log(_name +"進入待機狀態");
    }

    public override void ExitState()
    {
        Debug.Log(_name +"離開待機狀態");
    }

    public override void LogicUpdate()
    {
        //Debug.Log("玩家在閒置狀態");
        if(_playerControl.IsMove)
        {
            _controller.SetState(typeof(PlayerState_Move));
        }

        if(_playerControl.IsImpulse && _playerControl.CanImpulse)  
        {
            _controller.SetState(typeof(PlayerState_Impulse));
        }

        _playerControl.ImpulseBar += 10f * Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        // 物理相關的更新（如果有的話）
        if(_playerControl.IsShoot)
        {
            //_shipController.Shoot();
        }

        _shipController.Forward(_forwardSpeed);
    }
}
