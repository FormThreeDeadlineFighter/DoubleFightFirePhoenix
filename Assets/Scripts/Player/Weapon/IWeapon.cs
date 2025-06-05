using UnityEngine;
using UnityEngine.InputSystem;
public abstract class IWeapon : ScriptableObject
{
    [Header("Info")]
    [SerializeField] string _name; //武器名字
    [SerializeField] GameObject _weaponModel;

    [Header("Shoot")]
    float damage; //武器傷害
    float fireRate ; //射速
    float nextFireTime = 0f; //下一發射擊的冷卻時間

    [Header("Reload")]
    int maxAmmo; //最大子彈數
    protected int currentAmmo; //當前擁有的子彈
    protected bool hasAmmo => currentAmmo > 0; //判斷是否有子彈
    
    protected virtual void Reload() => currentAmmo = maxAmmo; //裝填子彈
    public abstract void InitializeWeapon(); 
    public abstract void Attack();
}
