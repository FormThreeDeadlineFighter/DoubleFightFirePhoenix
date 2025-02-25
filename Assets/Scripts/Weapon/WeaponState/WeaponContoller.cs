using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponContoller : MonoBehaviour
{
    private PlayerControl playerControl;
    public bool IsSwitch => playerControl.PlayerNormal.SwitchWeapon.IsPressed();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControl = new PlayerControl();
        playerControl.PlayerNormal.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Weapon_1()
    {
        //Instantiate(_bullet,transform.position,transform.rotation);
    }
}
