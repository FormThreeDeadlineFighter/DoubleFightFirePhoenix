using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerState_Idle : IPlayerState
{
    private PlayerStateController _controller;

    public bool IsComplete { get; private set; } = false; // 讓屬性可讀

    public PlayerState_Idle(PlayerStateController controller)
    {
        _controller = controller;
    }

    public void EnterState()
    {
        Debug.Log("玩家進入閒置狀態");
    }

    public void ExitState()
    {
        Debug.Log("玩家離開閒置狀態");
    }

    public void LogicUpdate()
    {

    }

    public void PhysicsUpdate()
    {
        // 物理相關的更新（如果有的話）
    }
}
