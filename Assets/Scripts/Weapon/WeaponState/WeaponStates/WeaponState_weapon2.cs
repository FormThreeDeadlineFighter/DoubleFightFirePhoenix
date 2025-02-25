using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/WeaponState/weapon2", fileName = "WeaponState_weapon2")]

public class WeaponState_weapon2 : IWeaponState
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject _bullet;

    public override void EnterState()
    {
        Debug.Log("武器2");
    }

    public override void ExitState()
    {
        Debug.Log("切換至武器1");
    }

    public override void LogicUpdate()
    {        
        if(_weaponContoller.IsSwitch)
        {            
            _controller.SetState(typeof(WeaponState_weapon1));
        }
    }

    public override void PhysicsUpdate()
    {

    }
}
