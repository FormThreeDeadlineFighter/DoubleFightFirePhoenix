using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Impulse", fileName = "PlayerState_Impulse")]
public class PlayerState_Impulse : IPlayerState
{
    [SerializeField] float _forceSpeed;
    [SerializeField] float _positionx;
    [SerializeField] float _drag;
    [SerializeField] float _barReduce;
    
    //進入加速狀態
    public override void EnterState()
    {
        //Debug.Log(_name + "進入加速狀態");
        _rb.AddForce(_shipController.transform.forward *_forceSpeed, ForceMode.Impulse);
        _rb.AddForce(new Vector3(_positionx,0,0), ForceMode.Impulse);
        
        _playerControl.ImpulseBar -= _barReduce * Time.deltaTime;
        //Debug.Log(_controller.ImpulseBar);
        
        IsComplete = false;
    }
    //離開加速狀態
    public override void ExitState()
    {
        Debug.Log(_name + "離開加速狀態");
    }

    public override void LogicUpdate()
    {
        if(!_playerControl.IsMove && IsComplete)
        {
            _controller.SetState(typeof(PlayerState_Idle));
        }   

        if(_playerControl.IsMove && IsComplete)  
        {
            _controller.SetState(typeof(PlayerState_Move));
        } 

        if(_playerControl.IsImpulse && _playerControl.CanImpulse)  
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
            IsComplete = true;
        } 
    }
}
