using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class SinglePlayerControl : MonoBehaviour
{
    //private InputUser _player;
    private PlayerInput _playerInput;
    private Vector2 _playerMoveVector;

    public bool IsMove => _playerMoveVector != Vector2.zero;
    public bool IsShoot => _playerInput.PlayerControl.Shoot.IsPressed();
    public bool IsImpulse => _playerInput.PlayerControl.Impulse.IsPressed();

    #region getset  
    public PlayerInput PlayerInput
    {   
        get { return _playerInput; } 
        set 
        { 
            if (_playerInput == null)
            { 
                _playerInput = value; 
            }
            else { return; }
           
        } 
    }

    public Vector2 PlayerMoveVector
    {
        get { return _playerMoveVector; }
        private set { PlayerMoveVector = _playerInput.PlayerControl.Move.ReadValue<Vector2>(); }
    }
    #endregion

    private void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



}
