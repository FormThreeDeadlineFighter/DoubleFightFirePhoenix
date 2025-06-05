using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AISensor))]
public class WeaponManager : MonoBehaviour
{
    // 存放所有可切換的武器，這些武器都必須繼承 IWeapon
    public IWeapon[] weapons;
    public Transform _firepoint;
    public Transform _weaponPosition;
    private int currentWeaponIndex = 0;

    private AISensor sensor;

    private void Start()
    {
        weapons[currentWeaponIndex] = SpawnWeapon(currentWeaponIndex);
        weapons[currentWeaponIndex].InitializeWeapon();
        //weapons[currentWeaponIndex].nextFireTime = 0;

        sensor = GetComponent<AISensor>();
    }
    
    void Update()
    {
        //weapons[currentWeaponIndex].nextFireTime -= Time.deltaTime;
    }

    private IWeapon SpawnWeapon(int weaponIndex)
    {
        //生成武器
        GameObject weaponInstance = Instantiate(weapons[weaponIndex].gameObject, _weaponPosition.transform.position, _weaponPosition.transform.rotation);
        
        // 設為 FirePoint 子物件
        weaponInstance.transform.SetParent(_weaponPosition.transform); 
        // 回傳實體的 IWeapon
        return weaponInstance.GetComponent<IWeapon>();             
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
        
        // 初始化新武器
        weapons[currentWeaponIndex].InitializeWeapon();
        }
    //Attack
    public void PlayerAttack()
    {
        if(sensor.Objects.Count != 0)
        {
            //weapons[currentWeaponIndex].Attack(_firepoint, sensor.Objects[0].transform);
            return;
        }
        //using current weapon attack
        //weapons[currentWeaponIndex].Attack(_firepoint);
    }
}
