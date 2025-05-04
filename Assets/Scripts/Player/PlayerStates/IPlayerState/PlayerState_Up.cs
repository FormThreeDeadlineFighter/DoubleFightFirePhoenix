using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Up", fileName = "PlayerState_Up")]
public class PlayerState_Up : IPlayerState
{
    [SerializeField] float _dirX;
    [SerializeField] float _dirY;
    //進入上升狀態
    public override void EnterState()
    {
        //ship up by dirY
        _shipController.ShipMoveAxesY(_dirY);
    }
    
    //離開上升狀態
    public override void ExitState()
    {
        //ship back to idle position
        _shipController.ShipMoveAxesY(-_dirY);
    }

    public override void LogicUpdate()
    {          
        if(!_playerControl.IsUp && !_playerControl.IsMove)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }
        if(!_playerControl.IsUp && _playerControl.IsMove)
        {
            _controller.SetState(typeof(PlayerState_Move));
        }
    }

    public override void PhysicsUpdate()
    {
        //Shooting
        if(_playerControl.IsShoot)
        {
            //use Weapon Attack          
            _weaponManager.Attack();
        }
        
         // ship move by dirX
        _shipController.ShipMoveAxesX(_dirX);

        // ship move forward
        _shipController.Forward();
        
    }
}
