using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Shooting", fileName = "PlayerState_Shooting")]
public class PlayerState_Shooting : IPlayerState
{
    [SerializeField] float _barReduce;
    
    //進入Shooting狀態
    public override void EnterState()
    {
        Debug.Log(_name +"進入Shooting");
    }
    //離開Shooting狀態
    public override void ExitState()
    {
        Debug.Log(_name +"離開Shooting");
    }

    public override void LogicUpdate()
    {

        if (!_playerControl.IsShoot && !!_playerControl.IsMoving)
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
        _weaponManager.Attack();       
    }
    
    
}
