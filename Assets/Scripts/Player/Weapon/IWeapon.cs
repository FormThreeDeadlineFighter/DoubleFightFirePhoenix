using UnityEngine;
using UnityEngine.InputSystem;
public abstract class IWeapon : MonoBehaviour
{
    
    public GameObject weaponModel; //武器模型
    public GameObject bulletPrefab; //子彈模型
    public float damage; //武器傷害
    public int maxAmmo; //最大子彈數
    public float fireRate ; //射速
    public float nextFireTime = 0f; //下一發射擊的冷卻時間
    protected int currentAmmo; //當前擁有的子彈
    protected bool hasAmmo => currentAmmo > 0; //判斷是否有子彈
    
    protected virtual void Reload() => currentAmmo = maxAmmo; //裝填子彈
    
    public abstract void InitializeWeapon(); 
    public abstract void Attack(Transform firePoint);

    public abstract void Attack(Transform firePoint, Transform enemyPosition);

}
