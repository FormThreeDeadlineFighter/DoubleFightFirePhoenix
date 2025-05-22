using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_2 : IWeapon
{
    public override void InitializeWeapon()
    {
        //現在子彈數等於最大數
        currentAmmo = maxAmmo;
    }

    public override void Attack(Transform firePoint)
    {
        if (hasAmmo)
        {
            if (nextFireTime <= 0)
            {
                currentAmmo--;

                if (bulletPrefab != null)
                {
                    FireTowardCrosshair(firePoint);
                }

                nextFireTime = fireRate;
                return;
            }
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
        //Debug.Log($"[{gameObject.name}] 準星鎖定點: {targetPoint}");

        Vector3 direction = (targetPoint - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        Instantiate(bulletPrefab, firePoint.transform.position, rotation);
    }
}
