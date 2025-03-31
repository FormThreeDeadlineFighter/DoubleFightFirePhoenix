using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_3 : IWeapon
{
    private void Start()
    {
        maxAmmo = 30; 
        fireRate = 3f;
    }

    public override void Attack()
    {
        if (HasAmmo)
        {
            currentAmmo--;
            Debug.Log($"Weapon_3 fired! Remaining ammo: {currentAmmo}");

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
}
