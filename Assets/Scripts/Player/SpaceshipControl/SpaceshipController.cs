using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;


public class SpaceshipController : MonoBehaviour
{
    //Ship HP
    [SerializeField] float _shipHealth;
    //Ship moving speed
    [SerializeField] float _shipMoveSpeed;
    // Ship forward speed
    [SerializeField] float _shipforwardSpeed;
    public bool PlayerUP => _playerControl1.IsUp && _playerControl2.IsUp;
    public bool PlayerDown => _playerControl1.IsDown && _playerControl2.IsDown;

    //public static SpaceshipController current;


    #region player manager
    [SerializeField] GameObject[] _players;
    
    private SinglePlayerControl _playerControl1 => _players[0].GetComponent<SinglePlayerControl>();
    private SinglePlayerControl _playerControl2 => _players[1].GetComponent<SinglePlayerControl>();

    private InputUser _player1;
    private InputUser _player2;
    
    #endregion

    #region accessor
    public float ShipHealth
    {
        get{ return _shipHealth;}
        private set
        {
            if(ShipHealth <= 0)
            {
                ShipHealth = 0;
            }
            else
            {
                ShipHealth = value;
            }
        }
    }

    #endregion

    //public event Action OnPlayerHurt;
    
    private void Awake()
    {
        _player1 = InputUser.CreateUserWithoutPairedDevices();
        _player2 = InputUser.CreateUserWithoutPairedDevices();

        InputUser.onUnpairedDeviceUsed += OnUnpairedDeviceUsed;       
        
        _playerControl1.PlayerInput = new PlayerInput();
        _playerControl2.PlayerInput = new PlayerInput();
    
        _player1.AssociateActionsWithUser(_playerControl1.PlayerInput);
        _player2.AssociateActionsWithUser(_playerControl2.PlayerInput);

        _playerControl1.PlayerInput.Enable();
        _playerControl2.PlayerInput.Enable();
    }
       
    private void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr)
    {
        var device = control.device;
        
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
                Debug.Log(device.ToString() + " assigned to Player 2");
            }
        }
    }

    public void ShipMoveAxesX(float dirX)
    {
        this.transform.Translate(dirX, 0, 0, Space.World);
    }
    
    public void ShipMoveAxesY(float dirY)
    {
        this.transform.Translate(0, dirY, 0, Space.World);
    }

    public void Forward()
    {
        this.transform.Translate(0, 0, _shipforwardSpeed/2 * Time.deltaTime, Space.World);
    }
    
    public void Forward(float forwardSpeed)
    {
        this.transform.Translate(0, 0, forwardSpeed * Time.deltaTime, Space.World);
    }

    /*public void PlayerHurt(int damage)
    {
        if(OnPlayerHurt != null)
        {
            _shipHealth -= damage;
            OnPlayerHurt();
        }
    }*/
}
