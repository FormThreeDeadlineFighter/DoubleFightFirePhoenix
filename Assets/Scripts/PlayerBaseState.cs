using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateManager player;
    public PlayerBaseState(PlayerStateManager player)
    {
        this.player = player;
    }
    public abstract void EnterState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void OncollisionEnter(PlayerStateManager player);
    public abstract void HandleInput(Vector2 movementInput);
}
