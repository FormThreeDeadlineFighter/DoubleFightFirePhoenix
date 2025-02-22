using UnityEngine;
using UnityEngine.InputSystem;

public class IPlayerState : ScriptableObject ,IState
{ 
    protected PlayerStateController _controller;

    protected Animator _animator;

    protected bool IsComplete { get; private set; }

    public void Initialize(PlayerStateController controller, Animator animator)
    {
        _controller = controller;
        _animator = animator;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }


}
