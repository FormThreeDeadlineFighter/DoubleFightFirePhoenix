using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_2 : IWeapon
{
    private CrosshairControl crosshairControl; // ✅ 自己存一個對應準星控制器
    public override void InitializeWeapon()
    {
        //現在子彈數等於最大數
        currentAmmo = maxAmmo;

        // ✅ 從父物件找 CrosshairControl（也就是自己玩家的）
        crosshairControl = GetComponentInParent<CrosshairControl>();
        if (crosshairControl == null)
        {
            Debug.LogWarning($"{gameObject.name} 找不到對應的 CrosshairControl！");
        }
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

        Vector3 targetPoint = crosshairControl.targetPoint;
        //Debug.Log($"[{gameObject.name}] 準星鎖定點: {targetPoint}");

        Vector3 direction = (targetPoint - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        Instantiate(bulletPrefab, firePoint.transform.position, rotation);
    }
}
