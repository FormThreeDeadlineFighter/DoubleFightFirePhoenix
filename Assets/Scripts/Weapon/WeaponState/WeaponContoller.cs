using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponContoller : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _weapon_1;
    [SerializeField] GameObject _weapon_2;
    private PlayerControl playerControl;
    public bool IsSwitch => playerControl.PlayerNormal.SwitchWeapon.IsPressed();
    public bool IsShoot_1 => playerControl.PlayerNormal.Player1_Shoot.IsPressed();
    public bool IsShoot_2 => playerControl.PlayerNormal.Player2_Shoot.IsPressed();
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
        Instantiate(_bullet,_weapon_1.transform.position,_weapon_1.transform.rotation);
        
        Instantiate(_bullet,_weapon_2.transform.position,_weapon_2.transform.rotation);
    }
    public void Weapon_2()
    {
        Instantiate(_bullet,_weapon_1.transform.position,_weapon_1.transform.rotation);

        Instantiate(_bullet,_weapon_2.transform.position,_weapon_2.transform.rotation);
    }
}
