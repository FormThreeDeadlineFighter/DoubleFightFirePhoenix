using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] GameObject _player1;
    [SerializeField] GameObject _player2;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _shipSpeed = 10;

    private PlayerControl playerControl;
    private Vector2 _moveVector;
    public bool IsShoot => playerControl.PlayerNormal.Shoot.IsPressed();

    public bool IsImpulse => playerControl.PlayerNormal.Impulse.IsPressed();
    public bool Move => _moveVector != Vector2.zero;

    public Vector2 MoveVector {get {return _moveVector;} private set {_moveVector = value;} }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControl = new PlayerControl();
        playerControl.PlayerNormal.Enable();
        playerControl.PlayerNormal.Move.performed += SetMoveDirection;
        playerControl.PlayerNormal.Move.canceled += SetMoveDirection;
    }

    public void ShipMove()
    {
        this.transform.position += new Vector3(_moveVector.x, _moveVector.y,0) * Time.deltaTime * _shipSpeed;
    }

    private void SetMoveDirection(InputAction.CallbackContext ctx)
    {
        _moveVector = ctx.ReadValue<Vector2>();
    }

    public void Shoot()
    {
        Instantiate(_bullet,transform.position,transform.rotation);
    }

    public void Forward(float forwardSpeed)
    {
        this.transform.Translate(0, 0, forwardSpeed * Time.deltaTime);
    }

}
