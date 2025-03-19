using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _shipSpeed = 10;

    private InputUser player1;
    private InputUser player2;

    private PlayerControl playerControl1;
    private PlayerControl playerControl2;
    private Vector2 _player1MoveVector;
    private Vector2 _player2MoveVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 创建两个用户
        player1 = InputUser.CreateUserWithoutPairedDevices();
        player2 = InputUser.CreateUserWithoutPairedDevices();

        // 监听设备的连接
        InputUser.onUnpairedDeviceUsed += OnUnpairedDeviceUsed;
        
        playerControl1 = new PlayerControl();
        playerControl2 = new PlayerControl();
        
        playerControl1.PlayerNormal.Enable();
        playerControl2.PlayerNormal.Enable();
        
        player1.AssociateActionsWithUser(playerControl1);
        player2.AssociateActionsWithUser(playerControl2);
        
        
        playerControl1.PlayerNormal.Move.performed += GetMoveVector1;
        playerControl1.PlayerNormal.Move.canceled += GetMoveVector1; 
        
        playerControl2.PlayerNormal.Move.performed += GetMoveVector2;                         
        playerControl2.PlayerNormal.Move.canceled += GetMoveVector2;
        
    }

    private void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr)
    {
        var device = control.device;
        
        // 如果是手柄设备，则自动分配给一个未分配设备的用户
        if (device is Gamepad || device is Keyboard)
        {
            if (player1.pairedDevices.Count == 0)
            {
                InputUser.PerformPairingWithDevice(device, player1);
                Debug.Log(device.ToString() + " assigned to Player 1");
            }
            else if (player2.pairedDevices.Count == 0)
            {
                InputUser.PerformPairingWithDevice(device, player2);
                Debug.Log(device.ToString() +" assigned to Player 2");
            }
        }
    }

    private void OnDisable()
    {
        // 清理事件监听
        InputUser.onUnpairedDeviceUsed -= OnUnpairedDeviceUsed;
    }

    public void ShipMove()
    {
        Vector2 finalMoveInput = (_player1MoveVector + _player2MoveVector).normalized;       
        Vector3 move = new Vector3(finalMoveInput.x, finalMoveInput.y, 0) * _shipSpeed * Time.deltaTime;
        
        transform.Translate(move, Space.World);
    }

    private void GetMoveVector1(InputAction.CallbackContext ctx)
    {
        _player1MoveVector = ctx.ReadValue<Vector2>();      
    }
    
    private void GetMoveVector2(InputAction.CallbackContext ctx)
    {  
        _player2MoveVector = ctx.ReadValue<Vector2>();   
    }

    public void Shoot()
    {   
        Instantiate(_bullet,transform.position,transform.rotation);
    }

    public void Forward(float forwardSpeed)
    {
        this.transform.Translate(0, 0, forwardSpeed * Time.deltaTime, Space.World);
    }
    
    public bool IsMove(string playerName)
    {
        switch(playerName)
        {
            case "player1":
            return _player1MoveVector != Vector2.zero;
            
            case "player2":
            return _player2MoveVector != Vector2.zero;
            
            default:
            return false;

        }
    }
    
    public bool IsShoot(string playerName)
    {
        switch(playerName)
        {
            case "player1":
            return playerControl1.PlayerNormal.Shoot.IsPressed();
            
            case "player2":
            return playerControl2.PlayerNormal.Shoot.IsPressed();
            
            default:
            return false;
        }
    }
    
    public bool IsImpulse(string playerName)
    {
        switch(playerName)
        {
            case "player1":
            return playerControl1.PlayerNormal.Impulse.IsPressed();
            
            case "player2":
            return playerControl2.PlayerNormal.Impulse.IsPressed();
            
            default:
            return false;
        }
    }

}
