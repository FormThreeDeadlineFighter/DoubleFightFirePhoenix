using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(AISensor))]
public class WeaponManager : MonoBehaviour
{
    // 存放所有可切換的武器，這些武器都必須繼承 IWeapon
    [SerializeField] IWeapon[] _weapons;
    Dictionary<System.Type, IWeapon> weaponTable;
    private IWeapon _currentWeapon;
    [SerializeField] Transform _weaponPosition;
    private AISensor sensor;

    private void Awake()
    {
        sensor = GetComponent<AISensor>();

        weaponTable = new Dictionary<System.Type, IWeapon>(_weapons.Count());

        foreach(IWeapon weapon in _weapons)
        {
            weaponTable.Add(weapon.GetType(), weapon);
        }

        _currentWeapon = weaponTable[typeof(Gun)];

        _currentWeapon.InitializeWeapon(_weaponPosition);
    }


    public void PlayerAttack()
    {
        Debug.Log("player attack");   
        if (sensor.Objects.Count > 0)
        {
            _currentWeapon.Attack(sensor.Objects[0].transform.position);
        }
        else
        {
            _currentWeapon.Attack(Vector3.forward);
        } 
    }
}
