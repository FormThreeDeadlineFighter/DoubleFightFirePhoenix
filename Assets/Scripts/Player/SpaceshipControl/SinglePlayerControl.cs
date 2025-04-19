using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

[RequireComponent(typeof(WeaponManager))]
public class SinglePlayerControl : MonoBehaviour
{
    // Unity input system : PlayerInput Script Creates
    private PlayerInput _playerInput;
    //player Move Vector
    private Vector2 _playerMoveVector => _playerInput.PlayerControl.Move.ReadValue<Vector2>();
    
    //player Look position
    public Vector2 _playerLookPosition => _playerInput.UI.Look.ReadValue<Vector2>();
    
    // Is player moving
    public bool IsMove => _playerMoveVector != Vector2.zero;
    // Is player shooting 
    public bool IsShoot => _playerInput.PlayerControl.Shoot.IsPressed();
    // Is player Impulsing
    public bool IsImpulse => _playerInput.PlayerControl.Impulse.IsPressed();

    // bar value
    [SerializeField] private float _impulseBarValue;       

    #region accessor
    public bool CanImpulse
    {
        get
        {
            if (_impulseBarValue <= 0)
            {
                return false;
            }
            return true;
        }
        private set { CanImpulse = value; }
    }
    public float ImpulseBar
    {
        get { return _impulseBarValue; }
        set
        {
            if (_impulseBarValue > 100)
            {
                _impulseBarValue = 100;
            }
            else if (_impulseBarValue < 0)
            {
                _impulseBarValue = 0;
            }
            else
                _impulseBarValue = value;
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
        //when Start sure bar value is 100
        _impulseBarValue = 100f;        
    }
}
