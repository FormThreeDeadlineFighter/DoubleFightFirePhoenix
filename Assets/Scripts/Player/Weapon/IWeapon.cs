using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    public float damage; //武器傷害
    public int maxAmmo; //最大子彈數
    public GameObject weaponModel; //武器模型
    public GameObject bulletPrefab; //子彈模型

    protected int currentAmmo; //當前子彈

    protected virtual void Awake()
    {
        currentAmmo = maxAmmo;
    }

    public abstract void Attack();

    public virtual void Reload()
    {
        currentAmmo = maxAmmo;
        Debug.Log($"{gameObject.name} reloaded.");
    }

    public bool HasAmmo()
    {
        return currentAmmo > 0;
    }
}
