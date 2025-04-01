using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_1 : IWeapon
{ 
    private void Start()
    {
        maxAmmo = 30; 
        fireRate = 0.1f;
        damage = 1;
    }
    #region 攻擊
    public override void Attack()
    {
        if (HasAmmo && Time.time >= nextFireTime)
        {
            currentAmmo--;
            Debug.Log($"Weapon_1 fired! Remaining ammo: {currentAmmo}");

            // Instantiate bullet if prefab exists
            if (bulletPrefab != null)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
            nextFireTime = Time.time + fireRate;
        }
        else
        {
            Debug.Log("Out of ammo!");
            Reload();
        }
    }
    #endregion
}
