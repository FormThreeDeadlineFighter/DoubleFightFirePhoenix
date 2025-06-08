using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AISensor))]
public class WeaponManager : MonoBehaviour
{
    // 存放所有可切換的武器，這些武器都必須繼承 IWeapon
    public IWeapon[] _weapons;
    [SerializeField] IWeapon _currentWeapon;
    public Transform _weaponPosition;
    private AISensor sensor;

    private void OnEnable()
    {
        sensor = GetComponent<AISensor>();

        if (_weapons != null)
        {
            _currentWeapon = _weapons[0];
        }

        _currentWeapon.InitializeWeapon(_weaponPosition);
    }
    

    public void PlayerAttack()
    {
        if(sensor.Objects.Count != 0)
        {
            _currentWeapon.Attack(sensor.Objects[0].transform.position);
            return;
        }
        _currentWeapon.Attack(Vector3.forward);
    }
}
