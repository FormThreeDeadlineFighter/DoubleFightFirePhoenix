using UnityEngine;
using UnityEngine.InputSystem;

public class IPlayerState : ScriptableObject ,IState
{ 
    protected PlayerStateController _controller;
    protected Animator _animator;
    protected SpaceshipController _shipController;

    protected bool IsComplete { get; private set; }

    public void Initialize(PlayerStateController controller, Animator animator, SpaceshipController spaceshipController)
    {
        _controller = controller;
        _animator = animator;
        _shipController = spaceshipController;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }


}
