using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Down", fileName = "PlayerState_Down")]
public class PlayerState_Down : IPlayerState
{
    [SerializeField] float _dirY;
    //進入下降狀態
    public override void EnterState()
    {
        //ship down by dirY
        _shipController.ShipMoveAxesY(-_dirY);
    }
    
    //離開下降狀態
    public override void ExitState()
    {
        //ship back to idle position
        _shipController.ShipMoveAxesY(_dirY);
    }

    public override void LogicUpdate()
    {
           if(!_shipController.PlayerDown && !_playerControl.IsMove)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }
        if(!_shipController.PlayerDown && _playerControl.IsMove)
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

        // ship move forward
        _shipController.Forward();
        
    }
}
