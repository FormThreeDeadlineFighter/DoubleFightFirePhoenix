using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_2 : IWeapon
{
    private void Start()
    {
        maxAmmo = 30; 
        fireRate = 2f;
    }

    public override void Attack()
    {
        if (HasAmmo)
        {
            currentAmmo--;
            Debug.Log($"Weapon_2 fired! Remaining ammo: {currentAmmo}");

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
