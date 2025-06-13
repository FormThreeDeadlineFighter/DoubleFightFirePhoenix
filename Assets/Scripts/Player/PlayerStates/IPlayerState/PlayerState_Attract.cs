using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Attracting", fileName = "PlayerState_Attracting")]
public class PlayerState_Attract : IPlayerState
{
    //進入Attracting狀態
    public override void EnterState()
    {
        Debug.Log(_name +"進入Attracting");
    }
    //離開Attracting狀態
    public override void ExitState()
    {
        Debug.Log(_name +"離開Attracting");
    }

    public override void LogicUpdate()
    {

        if (!_playerControl.IsShoot && !_playerControl.IsMoving)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }
        else if (!_playerControl.IsShoot && _playerControl.IsMoving)
        {
            _controller.SetState(typeof(PlayerState_Move));
        }  
    }

    public override void PhysicsUpdate()
    {
        _rb.position += Vector3.forward * _playerControl._forwardSpeed * Time.fixedDeltaTime;        
    }
    
    
}
