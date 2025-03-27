using UnityEngine;
using UnityEngine.InputSystem;

public class IPlayerState : ScriptableObject ,IState
{ 
    protected string _name;
    protected PlayerStateController _controller;
    protected Animator _animator;
    protected Rigidbody _rb;
    protected SpaceshipController _shipController;
    protected bool IsComplete;

    public void Initialize(PlayerStateController controller, Animator animator, SpaceshipController spaceshipController, Rigidbody rigidbody, string playerName)
    {
        _controller = controller;
        _animator = animator;
        _shipController = spaceshipController;
        _rb = rigidbody;
        _name = playerName;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }


}
