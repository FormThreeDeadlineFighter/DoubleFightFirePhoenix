using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(WeaponManager))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] public float _moveSpeed;
    // Unity input system : PlayerInput Script Creates
    //private PlayerInput _playerInput;
    // Is player shooting 
    public bool IsShoot;
    //Moving Value
    public Vector2 MoveValue;
    // Is Moving
    public bool IsMoving => MoveValue != Vector2.zero;    
    
    void Awake()
    {
        //_playerInput = new PlayerInput();
        //_playerInput.Enable();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveValue = context.action.ReadValue<Vector2>();
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            IsShoot = true;
        }
        else
        {
            IsShoot = false;
        }
    }
}
