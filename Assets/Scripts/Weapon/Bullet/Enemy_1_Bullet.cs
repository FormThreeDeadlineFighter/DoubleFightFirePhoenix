using UnityEngine;

public class Enemy_1_Bullet : MonoBehaviour
{
    int speed = 10;
    
    void Update()
    {
        transform.Translate(Vector3.back*speed*Time.deltaTime);
    }
}
