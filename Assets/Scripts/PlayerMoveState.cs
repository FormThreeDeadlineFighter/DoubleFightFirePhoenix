using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateManager player) : base(player){}
    public override void EnterState(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    public override void OncollisionEnter(PlayerStateManager player)
    {       

    }

    public override void HandleInput(Vector2 movementInput)
    {       
        if(movementInput.magnitude > 0.1f)
        {
            
        }
    }    
}
