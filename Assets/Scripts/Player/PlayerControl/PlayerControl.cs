using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(WeaponManager))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] public float _moveSpeed;
    [SerializeField] public float _forwardSpeed;

    // Is player shooting 
    public bool IsShoot;
    //Moving Value
    public Vector2 MoveValue;
    // Is Moving
    public bool IsMoving => MoveValue != Vector2.zero;    
    
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
