using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] GameObject _player1;
    [SerializeField] GameObject _player2;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _shipSpeed = 10;

    private InputUser player1;
    private InputUser player2;

    private PlayerControl playerControl;
    private Vector2 _moveVector;
    public bool IsShoot => playerControl.PlayerNormal.Shoot.IsPressed();

    public bool IsImpulse => playerControl.PlayerNormal.Impulse.IsPressed();
    public bool Move => _moveVector != Vector2.zero;

    public Vector2 MoveVector {get {return _moveVector;} private set {_moveVector = value;} }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 创建两个用户
        player1 = InputUser.CreateUserWithoutPairedDevices();
        player2 = InputUser.CreateUserWithoutPairedDevices();

        // 监听设备的连接
        InputUser.onUnpairedDeviceUsed += OnUnpairedDeviceUsed;

        playerControl = new PlayerControl();
        playerControl.PlayerNormal.Enable();
        playerControl.PlayerNormal.Move.performed += SetMoveDirection;
        playerControl.PlayerNormal.Move.canceled += SetMoveDirection;     
    }

    private void OnUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr)
    {
        var device = control.device;

        // 如果是手柄设备，则自动分配给一个未分配设备的用户
        if (device is Gamepad)
        {
            if (player1.pairedDevices.Count == 0)
            {
                InputUser.PerformPairingWithDevice(device, player1);
                Debug.Log("Gamepad assigned to Player 1");
            }
            else if (player2.pairedDevices.Count == 0)
            {
                InputUser.PerformPairingWithDevice(device, player2);
                Debug.Log("Gamepad assigned to Player 2");
            }
        }
    }

    private void OnDisable()
    {
        // 清理事件监听
        InputUser.onUnpairedDeviceUsed -= OnUnpairedDeviceUsed;
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
        Instantiate(_bullet,transform.position + new Vector3(0,0,5),transform.rotation);
    }

    public void Forward(float forwardSpeed)
    {
        this.transform.Translate(0, 0, forwardSpeed * Time.deltaTime);
    }

}
