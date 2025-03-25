using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;


public class SpaceshipController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _shipSpeed = 10;
    [SerializeField] GameObject[] _players;
    
    private SinglePlayerControl[] _playerControls;

    private InputUser _player1;
    private InputUser _player2;

    private PlayerInput _playerInput1;
    private PlayerInput _playerInput2;

    private Vector2 _player1MoveVector => _playerControls[0].PlayerMoveVector;
    private Vector2 _player2MoveVector => _playerControls[1].PlayerMoveVector;

    private void Awake()
    {
        _player1 = _playerControls[0].Player;
        _player2 = _playerControls[1].Player;


        InputUser.onUnpairedDeviceUsed += OnUnpairedDeviceUsed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {          
        _player1.AssociateActionsWithUser(_playerControls[0].PlayerInput);
        _player2.AssociateActionsWithUser(_playerControls[1].PlayerInput);

        _playerControls[0].PlayerInput.Enable();
        _playerControls[1].PlayerInput.Enable();
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
                Debug.Log(device.ToString() +" assigned to Player 2");
            }
        }
    }

    private void OnDisable()
    {
        InputUser.onUnpairedDeviceUsed -= OnUnpairedDeviceUsed;
    }

    public void ShipMove()
    {
        Vector2 finalMoveInput = (_player1MoveVector + _player2MoveVector).normalized;       
        Vector3 move = new Vector3(finalMoveInput.x, finalMoveInput.y, 0) * _shipSpeed * Time.deltaTime;
        
        transform.Translate(move, Space.World);
    }

    /*public void Shoot()
    {   
        Instantiate(_bullet,transform.position,transform.rotation);
    }*/

    public void Forward(float forwardSpeed)
    {
        this.transform.Translate(0, 0, forwardSpeed * Time.deltaTime, Space.World);
    }


}
