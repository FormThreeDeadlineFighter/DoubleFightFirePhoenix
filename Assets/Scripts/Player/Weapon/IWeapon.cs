
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] protected string _name; //武器名字
    [SerializeField] protected GameObject _weaponModel;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected GameObject _bullet;

    [Header("Shoot")]
    [SerializeField] protected float _damage; //武器傷害
    [SerializeField] protected float _fireRate; //射速
    [SerializeField] protected bool _canAttack;

    [Header("Reload")]
    [SerializeField] protected int maxAmmo; //最大子彈數
    [SerializeField] protected int currentAmmo; //當前擁有的子彈
    [SerializeField] protected bool hasAmmo => currentAmmo > 0; //判斷是否有子彈

    protected virtual void Reload() => currentAmmo = maxAmmo; //裝填子彈
    public virtual void InitializeWeapon() { }
    public virtual void Attack(Vector3 target) { }
}
