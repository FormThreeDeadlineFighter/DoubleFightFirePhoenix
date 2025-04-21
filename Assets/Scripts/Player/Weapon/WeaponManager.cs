using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponManager : MonoBehaviour
{
    // 存放所有可切換的武器，這些武器都必須繼承 IWeapon
    public IWeapon[] weapons;
    public GameObject _firepoint;
    private int currentWeaponIndex = 0;
    
    private void Awake()
    {
    }

    private void Start()
    {
        weapons[currentWeaponIndex] = SpawnWeapon(currentWeaponIndex);
    }

    private IWeapon SpawnWeapon(int weaponIndex)
    {
        GameObject weaponInstance = Instantiate(
            weapons[weaponIndex].gameObject,
            _firepoint.transform.position,
            _firepoint.transform.rotation
        );

        weaponInstance.transform.SetParent(_firepoint.transform); // 設為 FirePoint 子物件
        return weaponInstance.GetComponent<IWeapon>();             // 回傳實體的 IWeapon
    }


    private void Update()
    {

    }
    public void SwitchWeapon()
    {  
        // 刪除目前武器（如果有的話）
        if (weapons[currentWeaponIndex] != null)
        {
            Destroy(weapons[currentWeaponIndex].gameObject);
        }

        // 切換到下一個武器（環狀）
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;

        // 生成並儲存新武器
        weapons[currentWeaponIndex] = SpawnWeapon(currentWeaponIndex);

        Debug.Log("切換到武器：" + weapons[currentWeaponIndex].name);        

        
        }

    public void Attack()
    {
        weapons[currentWeaponIndex].Attack();
    }
}
