using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,Player.transform.position.z-16); 
    }
}
