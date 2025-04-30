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

    }
    //離開加速狀態
    public override void ExitState()
    {
        Debug.Log(_name + "離開加速狀態");
    }

    public override void LogicUpdate()
    {
        
              
    }

    public override void PhysicsUpdate()
    {  

    }
}
