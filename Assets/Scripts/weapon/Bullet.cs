using UnityEngine;

public class Bullet : MonoBehaviour
{
    int speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        transform.Translate(Vector3.forward*speed);
    }
}
