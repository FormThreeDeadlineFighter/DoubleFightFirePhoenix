using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot(InputAction.CallbackContext shoot)
    {
        Instantiate(bullet,transform.position,transform.rotation);
    }
}
