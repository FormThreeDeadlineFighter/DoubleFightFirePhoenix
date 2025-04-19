using UnityEngine;
using UnityEngine.InputSystem;

public class IPlayerState : ScriptableObject ,IState
{ 
    protected string _name;
    protected PlayerStateController _controller;
    protected Animator _animator;
    protected Rigidbody _rb;
    protected SinglePlayerControl _playerControl;
    protected SpaceshipController _shipController;
    protected WeaponManager _weaponManager;
    protected bool IsComplete;

    public void Initialize(PlayerStateController controller, Animator animator, SinglePlayerControl playerControl, SpaceshipController spaceshipController, Rigidbody rigidbody, WeaponManager weaponManager, string playerName)
    {
        _controller = controller;
        _animator = animator;
        _playerControl = playerControl;
        _shipController = spaceshipController;
        _rb = rigidbody;
        _weaponManager = weaponManager;
        _name = playerName;
    }
    // when enter state happen
    public virtual void EnterState() { }
    // when exit state happen
    public virtual void ExitState() { }
    // state update, not using physics
    public virtual void LogicUpdate() { }
    // state update, using physics
    public virtual void PhysicsUpdate() { }


}
