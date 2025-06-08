using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(AISensor))]
public class WeaponManager : MonoBehaviour
{
    // 存放所有可切換的武器，這些武器都必須繼承 IWeapon
    [SerializeField] IWeapon[] _weapons;
    private IWeapon _currentWeapon;
    [SerializeField] Transform _weaponPosition;
    private AISensor sensor;

    private void Awake()
    {
        sensor = GetComponent<AISensor>();

        GameObject weapon = Instantiate(_weapons[0].gameObject, _weaponPosition);

        _currentWeapon = weapon.GetComponent<IWeapon>();

        _currentWeapon.InitializeWeapon();
    }


    public void PlayerAttack()
    {
        Debug.Log("player attack");   
        if (sensor.Objects.Count > 0)
        {
            _currentWeapon.Attack(sensor.Objects[0].transform.position);
        }
        
    }
}
