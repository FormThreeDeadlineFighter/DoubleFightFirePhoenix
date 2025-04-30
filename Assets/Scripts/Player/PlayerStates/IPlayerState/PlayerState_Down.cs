using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Down", fileName = "PlayerState_Down")]
public class PlayerState_Down : IPlayerState
{
    [SerializeField] float _dirX;
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
