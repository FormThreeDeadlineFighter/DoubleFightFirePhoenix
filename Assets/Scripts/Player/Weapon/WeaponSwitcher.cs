using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponSwitcher : MonoBehaviour
{
    // 存放所有可切換的武器，這些武器都必須繼承 IWeapon
    public IWeapon[] weapons;
    private int currentWeaponIndex = 0;

    private void Start()
    {
        // 初始化時只啟用當前武器，其他武器關閉
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == currentWeaponIndex);
        }
    }

    private void Update()
    {
        // 當按下 Q 鍵時切換武器
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }

    private void SwitchWeapon()
    {
        // 停用目前武器
        weapons[currentWeaponIndex].gameObject.SetActive(false);

        // 切換到下一個武器（環狀）
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;

        // 啟用新武器
        weapons[currentWeaponIndex].gameObject.SetActive(true);

        Debug.Log("切換到武器：" + weapons[currentWeaponIndex].name);
    }
    /*private void SwitchWeapon(InputAction.CallbackContext ctx)
    {  
        // 停用目前武器
        weapons[currentWeaponIndex].gameObject.SetActive(false);

        // 切換到下一個武器（環狀）
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;

        // 啟用新武器
        weapons[currentWeaponIndex].gameObject.SetActive(true);

        Debug.Log("切換到武器：" + weapons[currentWeaponIndex].name);  
    }*/
}
