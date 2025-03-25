using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class SinglePlayerControl : MonoBehaviour
{
    private InputUser _player;
    private PlayerInput _playerInput;
    private Vector2 _playerMoveVector;

    public bool IsMove => _playerMoveVector != Vector2.zero;
    public bool IsShoot => _playerInput.PlayerControl.Shoot.IsPressed();
    public bool IsImpulse => _playerInput.PlayerControl.Impulse.IsPressed();

    #region ¦s¨ú¾¹
    public InputUser Player
    {
        get { return _player; }
        set 
        { 
            if (_player == null)
            { 
                _player = value; 
            }
            else { return; }
        }
    } 

    public PlayerInput PlayerInput
    {   
        get { return _playerInput; } 
        set { PlayerInput = _playerInput; } 
    }

    public Vector2 PlayerMoveVector
    {
        get { return _playerMoveVector; }
        private set { PlayerMoveVector = _playerInput.PlayerControl.Move.ReadValue<Vector2>(); }
    }
    #endregion

    private void Awake()
    {
        _player = InputUser.CreateUserWithoutPairedDevices();
        _playerInput = new PlayerInput();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerInput.Enable();
    }



}
