using UnityEngine;
using UnityEngine.InputSystem;
public class IWeaponState : ScriptableObject ,IState_weapon
{
    
    protected WeaponStateController _controller;
    protected Animator _animator;
    protected Rigidbody _rb;
    protected WeaponContoller _weaponContoller;

    protected bool IsComplete { get; private set; }

    public void Initialize(WeaponStateController controller, Animator animator, WeaponContoller weaponContoller, Rigidbody rigidbody)
    {
        _controller = controller;
        _animator = animator;
        _weaponContoller = weaponContoller;
        _rb = rigidbody;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }
}
