using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/WeaponState/weapon1", fileName = "WeaponState_weapon1")]

public class WeaponState_weapon1 : IWeaponState
{
    [SerializeField] float _waitTime = 0f;
    [SerializeField] GameObject _bullet;
    public override void EnterState()
    {
        Debug.Log("武器1");
    }

    public override void ExitState()
    {
        Debug.Log("切換至武器2");
    }

    public override void LogicUpdate()
    {
        _waitTime += Time.deltaTime;

        if(_weaponContoller.IsSwitch && _waitTime >= 1f)
        {
            _waitTime = 0f;
            
            _controller.SetState(typeof(WeaponState_weapon2));
        }
    }

    public override void PhysicsUpdate()
    {
        if(_weaponContoller.IsShoot_1)
        {
            _weaponContoller.Weapon_1();
        }
        if(_weaponContoller.IsShoot_2)
        {
            _weaponContoller.Weapon_1();
        }
    }
}
