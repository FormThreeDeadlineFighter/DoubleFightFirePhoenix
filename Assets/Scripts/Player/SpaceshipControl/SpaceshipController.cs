using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;


public class SpaceshipController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _shipSpeed = 10;

    private InputUser _player1;
    private InputUser _player2;

    private PlayerInput _playerInput1;
    private PlayerInput _playerInput2;
    public PlayerInput PlayerInput1 { get { return _playerInput1; } private set { PlayerInput1 = _playerInput1; } }
    public PlayerInput PlayerInput2 { get { return _playerInput2; } private set { PlayerInput2 = _playerInput2; } }

    private Vector2 _player1MoveVector;
    private Vector2 _player2MoveVector;

    private void Awake()
    {
        // 创建两个用户
        _player1 = InputUser.CreateUserWithoutPairedDevices();
        _player2 = InputUser.CreateUserWithoutPairedDevices();

        // 监听设备的连接
        InputUser.onUnpairedDeviceUsed += OnUnpairedDeviceUsed;

        _playerInput1 = new PlayerInput();
        _playerInput2 = new PlayerInput();

        _playerInput1.PlayerControl.Enable();
        _playerInput2.PlayerControl.Enable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {          
        _player1.AssociateActionsWithUser(_playerInput1);
        _player2.AssociateActionsWithUser(_playerInput2);
        
        
        _playerInput1.PlayerControl.Move.performed += GetMoveVector1;
        _playerInput1.PlayerControl.Move.canceled += GetMoveVector1; 
        
        _playerInput2.PlayerControl.Move.performed += GetMoveVector2;                         
        _playerInput2.PlayerControl.Move.canceled += GetMoveVector2;
        
    }

    private void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr)
    {
        var device = control.device;
        
        // 如果是手柄设备，则自动分配给一个未分配设备的用户
        if (device is Gamepad || device is Keyboard)
        {
            if (_player1.pairedDevices.Count == 0)
            {
                InputUser.PerformPairingWithDevice(device, _player1);
                Debug.Log(device.ToString() + " assigned to Player 1");
            }
            else if (_player2.pairedDevices.Count == 0)
            {
                InputUser.PerformPairingWithDevice(device, _player2);
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
            return _playerInput1.PlayerControl.Shoot.IsPressed();
            
            case "player2":
            return _playerInput2.PlayerControl.Shoot.IsPressed();
            
            default:
            return false;
        }
    }
    
    public bool IsImpulse(string playerName)
    {
        switch(playerName)
        {
            case "player1":
            return _playerInput1.PlayerControl.Impulse.IsPressed();
            
            case "player2":
            return _playerInput2.PlayerControl.Impulse.IsPressed();
            
            default:
            return false;
        }
    }

}
