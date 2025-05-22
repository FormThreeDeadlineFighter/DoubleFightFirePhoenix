using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_3 : IWeapon
{
    public override void InitializeWeapon()
    {
        maxAmmo = 30;
        fireRate = 0.1f;
        damage = 2;
    }

    public override void Attack(Transform firePoint)
    {
        if (hasAmmo && Time.time >= nextFireTime)
        {
            currentAmmo--;
            Debug.Log($"Weapon_1 fired! Remaining ammo: {currentAmmo}");

            if (bulletPrefab != null)
            {
                FireTowardCrosshair(firePoint);
            }

            nextFireTime = Time.time + fireRate;
        }
        else
        {
            Debug.Log("Out of ammo!");
            Reload();
        }
    }
    private void FireTowardCrosshair(Transform firePoint)
    {

        Vector3 targetPoint = Vector3.forward;
        Debug.Log($"[{gameObject.name}] 準星鎖定點: {targetPoint}");

        Vector3 direction = (targetPoint - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        Instantiate(bulletPrefab, firePoint.transform.position, rotation);
    }
}
