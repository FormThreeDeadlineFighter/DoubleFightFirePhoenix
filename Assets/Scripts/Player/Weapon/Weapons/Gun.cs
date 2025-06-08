using UnityEngine;
using System.Collections;
[System.Serializable]
public class Gun : IWeapon
{
    public override void InitializeWeapon(Transform weaponPosition)
    {
        Instantiate(_weaponModel, weaponPosition.transform.position, weaponPosition.transform.rotation, weaponPosition);
        _firePoint = weaponPosition;
        _canAttack = true;
    }

    public override void Attack(Vector3 target)
    {
        Vector3 dir = (target - _firePoint.transform.position).normalized;
        Quaternion quat = Quaternion.LookRotation(dir);
        Instantiate(_bullet, _firePoint.transform.position, quat);
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        _canAttack = false;
        Debug.Log("Cannot attack");
        yield return new WaitForSeconds(_fireRate);
        _canAttack = true;
        Debug.Log("Can attack");
    }
}
