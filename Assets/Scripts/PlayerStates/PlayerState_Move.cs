using UnityEngine;

public class PlayerState_Move : IPlayerState
{
    private PlayerStateController _controller;
    public bool IsComplete { get; private set; } = false; // 讓屬性可讀
    public PlayerState_Move(PlayerStateController controller)
    {
        _controller = controller;
    }

    public void EnterState()
    {
        Debug.Log("玩家進入移動狀態");
    }

    public void ExitState()
    {
        Debug.Log("玩家離開移動狀態");
    }

    public void LogicUpdate()
    {
        Debug.Log("玩家正在移動狀態");        
    }

    public void PhysicsUpdate()
    {
        
    }
}
