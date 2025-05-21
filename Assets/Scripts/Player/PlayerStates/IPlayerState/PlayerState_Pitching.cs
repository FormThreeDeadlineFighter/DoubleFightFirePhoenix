using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Pitching", fileName = "PlayerState_Pitching")]
public class PlayerState_Pitching : IPlayerState
{
    [SerializeField] float _dirX;
    [SerializeField] float _barReduce;
    //進入移動狀態
    public override void EnterState()
    {
        Debug.Log(_name +"進入Pitching");
        
        // 減動力槽
        
        
    }
    //離開移動狀態
    public override void ExitState()
    {
        Debug.Log(_name +"離開Pitching");
    }

    public override void LogicUpdate()
    {
           
        if(!_playerControl.IsMove)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }   
       
    }

    public override void PhysicsUpdate()
    {
        //Shooting
        if(_playerControl.IsShoot)
        {
            //Debug.Log($"{ _name}akkack");
            _weaponManager.Attack();
        }
        
        // ship move by dirX
        _shipController.ShipMoveAxesX(_dirX);

        // ship move forward
        _shipController.Forward();
        
    }
    
    
}
