using UnityEngine;
[System.Serializable]
public class Gun : IWeapon
{
    public override void InitializeWeapon(Transform weaponPosition)
    {
        Instantiate(_weaponModel, weaponPosition.position, weaponPosition.rotation, weaponPosition);

        _canAttack = true;
    }
    public override void Attack(Vector3 target)
    {
        Vector3 dir = (target - _firePoint.position).normalized;
        Quaternion quat = Quaternion.LookRotation(dir);
        Instantiate(_bullet, _firePoint.position, quat);
        StartCoroutine(FireRate());
    }

}
