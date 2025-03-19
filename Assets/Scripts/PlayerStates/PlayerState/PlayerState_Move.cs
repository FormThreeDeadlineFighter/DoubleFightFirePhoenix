using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Move", fileName = "PlayerState_Move")]
public class PlayerState_Move : IPlayerState
{
    [SerializeField] float _forwardSpeed;

    public override void EnterState()
    {
        Debug.Log(_controller.PlayerName +"進入移動狀態");
    }

    public override void ExitState()
    {
        Debug.Log(_controller.PlayerName +"離開移動狀態");
    }

    public override void LogicUpdate()
    {
        Debug.Log(_controller.PlayerName +"正在移動");
        
        if(!_shipController.IsMove(_controller.PlayerName))
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }   

        if(_shipController.IsImpulse(_controller.PlayerName))  
        {
            _controller.SetState(typeof(PlayerState_Impulse));
        }  
    }

    public override void PhysicsUpdate()
    {
        _shipController.ShipMove();

        _shipController.Forward(_forwardSpeed);
    }
}
