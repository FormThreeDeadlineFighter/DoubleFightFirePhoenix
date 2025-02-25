using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Impulse", fileName = "PlayerState_Impulse")]
public class PlayerState_Impulse : IPlayerState
{
    [SerializeField] float _forceSpeed;
    [SerializeField] float _drag;
    bool _impulseEnd;

    public override void EnterState()
    {
        Debug.Log("玩家進入加速狀態");
        _rb.AddForce(_shipController.transform.forward *_forceSpeed, ForceMode.Impulse);
       _impulseEnd = false;
    }

    public override void ExitState()
    {
        Debug.Log("玩家離開加速狀態");
    }

    public override void LogicUpdate()
    {
        if(!_shipController.Move && _impulseEnd)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }   

        if(_shipController.Move && _impulseEnd)  
        {
            _controller.SetState(typeof(PlayerState_Move));
        } 

        if(_shipController.IsImpulse)  
        {
            _controller.SetState(typeof(PlayerState_Impulse));
        }
              
    }

    public override void PhysicsUpdate()
    {  
        _shipController.ShipMove();

        if (_rb.linearVelocity.magnitude > 10f) // 避免誤差導致無法靜止
        {
            _rb.linearVelocity *= _drag; 
        }
        else
        {
            _rb.linearVelocity = Vector3.forward * 10;
            _impulseEnd = true;
        } 
    }
}
