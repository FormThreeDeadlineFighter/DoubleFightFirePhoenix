using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    private Vector2 moveVector;
    public int speed = 10;
    void Start()
    {
        
    }
    void Update()
    {
        if(moveVector != Vector2.zero)
        {
            this.transform.position += new Vector3(moveVector.x,moveVector.y,0) * Time.deltaTime * speed;
        }
    }
    public void Shoot(InputAction.CallbackContext shoot)
    {
        Instantiate(bullet,transform.position,transform.rotation);
    }

    public void Move(InputAction.CallbackContext move)
    {
        moveVector = move.ReadValue<Vector2>();
    }
}
