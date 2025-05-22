using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

[RequireComponent(typeof(WeaponManager))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] public float _moveSpeed;
    // Unity input system : PlayerInput Script Creates
    private PlayerInput _playerInput;
    // Is player shooting 
    public bool IsShoot => _playerInput.PlayerControl.Shoot.IsPressed();
    //Moving Value
    public Vector2 MoveValue => _playerInput.PlayerControl.Move.ReadValue<Vector2>();
    // Is Moving
    public bool IsMoving => MoveValue != Vector2.zero;    

    
    #region accessor
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
    #endregion
    
    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }
}
