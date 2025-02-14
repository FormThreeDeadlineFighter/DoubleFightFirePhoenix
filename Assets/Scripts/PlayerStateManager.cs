using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerStateManager : MonoBehaviour
{
    public PlyerIdleState IdleState;
    public PlayerMoveState MoveState;
    public PlayerAttackState AttackState;
    private PlayerBaseState currentState;
    
    
    private void Awake()
    {
        IdleState = new PlyerIdleState(this);
        MoveState = new PlayerMoveState(this);
        AttackState = new PlayerAttackState(this);
    }
    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

}
