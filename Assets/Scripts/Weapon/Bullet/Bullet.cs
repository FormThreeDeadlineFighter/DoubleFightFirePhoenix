using UnityEngine;

public class Bullet : MonoBehaviour
{
    int speed = 100;
    
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
}
