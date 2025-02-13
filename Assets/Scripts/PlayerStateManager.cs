using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    PlayerMoveState MoveState = new PlayerMoveState();
    PlayerAttackState AttackState = new PlayerAttackState();

    void Start()
    {
        currentState = MoveState;

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
        state.EnterState(this);
    }

}
