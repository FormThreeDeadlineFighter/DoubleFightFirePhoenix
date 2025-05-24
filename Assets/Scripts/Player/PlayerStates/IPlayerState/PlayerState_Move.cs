using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Move", fileName = "PlayerState_Move")]
[System.Serializable]
public class PlayerState_Move : IPlayerState
{
    [SerializeField] float _dirX;
    
    //進入移動狀態
    public override void EnterState()
    {
        Debug.Log(_name +"進入移動狀態");       
    }
    //離開移動狀態
    public override void ExitState()
    {
        Debug.Log(_name +"離開移動狀態");
    }

    public override void LogicUpdate()
    {
           
        if(!_playerControl.IsMoving)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        } 
        else if (_playerControl.IsShoot)
        {
            _controller.SetState(typeof(PlayerState_Shooting));
        }  
       
    }

    public override void PhysicsUpdate()
    {
        _rb.position += new Vector3(_playerControl.MoveValue.x,_playerControl.MoveValue.y,0) * _playerControl._moveSpeed * Time.fixedDeltaTime;
        _rb.position += Vector3.forward * _playerControl._forwardSpeed * Time.fixedDeltaTime;
    }
    
    
}
