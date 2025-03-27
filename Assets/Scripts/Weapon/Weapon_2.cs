using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_2 : IWeapon
{
    public float fireRate = 0.1f;
    private float nextFireTime = 0f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Attack();
            nextFireTime = Time.time + fireRate;
        }
    }

    public override void Attack()
    {
        if (HasAmmo)
        {
            currentAmmo--;
            Debug.Log($"Rifle fired! Remaining ammo: {currentAmmo}");

            // Instantiate bullet if prefab exists
            if (bulletPrefab != null)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
