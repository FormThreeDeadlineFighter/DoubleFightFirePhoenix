using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_1 : IWeapon
{
    private CrosshairControl crosshairControl; // ✅ 自己存一個對應準星控制器

    private void Start()
    {
        maxAmmo = 30;
        fireRate = 0.1f;
        damage = 2;

        // ✅ 從父物件找 CrosshairControl（也就是自己玩家的）
        crosshairControl = GetComponentInParent<CrosshairControl>();
        if (crosshairControl == null)
        {
            Debug.LogWarning($"{gameObject.name} 找不到對應的 CrosshairControl！");
        }
    }

    private void Update()
    {
        // 用 damage 當攻擊冷卻（如果是測試用 ok）
        /*damage -= Time.deltaTime;
        if (damage <= 0)
        {
            damage = 2f;
            FireTowardCrosshair(); // ✅ 改名比較清楚
        }*/
    }

    public override void Attack()
    {
        if (HasAmmo && Time.time >= nextFireTime)
        {
            currentAmmo--;
            Debug.Log($"Weapon_1 fired! Remaining ammo: {currentAmmo}");

            if (bulletPrefab != null)
            {
                FireTowardCrosshair();
            }

            nextFireTime = Time.time + fireRate;
        }
        else
        {
            Debug.Log("Out of ammo!");
            Reload();
        }
    }

    private void FireTowardCrosshair()
    {
        if (crosshairControl == null) return;

        Vector3 targetPoint = crosshairControl.targetPoint;
        Debug.Log($"[{gameObject.name}] 準星鎖定點: {targetPoint}");

        Vector3 direction = (targetPoint - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        Instantiate(bulletPrefab, transform.position, rotation);
    }
}
