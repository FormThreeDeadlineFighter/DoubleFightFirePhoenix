using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Move", fileName = "PlayerState_Move")]
public class PlayerState_Move : IPlayerState
{
    public override void EnterState()
    {
        Debug.Log(_name +"進入移動狀態");
    }

    public override void ExitState()
    {
        Debug.Log(_name +"離開移動狀態");
    }

    public override void LogicUpdate()
    {
        Debug.Log(_name +"正在移動");
        
        if(!_playerControl.IsMove)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }   

        if(_playerControl.IsImpulse && _playerControl.CanImpulse)  
        {
            _controller.SetState(typeof(PlayerState_Impulse));
        }  
        
        _playerControl.ImpulseBar += 10f * Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        _shipController.ShipMove();

        _shipController.Forward();
    }
}
