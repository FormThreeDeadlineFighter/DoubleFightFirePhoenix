using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class SinglePlayerControl : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Vector2 _playerMoveVector => _playerInput.PlayerControl.Move.ReadValue<Vector2>();
    public Vector2 _playerLookPosition => _playerInput.UI.Look.ReadValue<Vector2>();
    public bool IsMove => _playerMoveVector != Vector2.zero;
    public bool IsShoot => _playerInput.PlayerControl.Shoot.IsPressed();
    public bool IsImpulse => _playerInput.PlayerControl.Impulse.IsPressed();

    [SerializeField] private float _impulseBar = 100f;

    #region getset
    public bool CanImpulse
    {
        get
        {
            if (_impulseBar <= 0)
            {
                return false;
            }
            return true;
        }
        private set { CanImpulse = value; }
    }
    public float ImpulseBar
    {
        get { return _impulseBar; }
        set
        {
            if (_impulseBar > 100)
            {
                _impulseBar = 100;
            }
            else if (_impulseBar < 0)
            {
                _impulseBar = 0;
            }
            else
                _impulseBar = value;
        }
    }
    public PlayerInput PlayerInput
    {   
        get { return _playerInput; } 
        set 
        { 
            if (_playerInput == null)
            { 
                _playerInput = value; 
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
        } 
    }
    public Vector2 PlayerMoveVector
    {
        get { return _playerMoveVector; }
    }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _impulseBar = 100f;
    }
}
