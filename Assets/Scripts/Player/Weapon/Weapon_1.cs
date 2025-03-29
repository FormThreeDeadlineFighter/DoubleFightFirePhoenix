using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_1 : IWeapon
{
    public float fireRate = 0.1f;
    private float nextFireTime = 0f;
    

    private void Update()
    {
        
    }

    public override void Attack(Transform transform)
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
