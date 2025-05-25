using UnityEngine;

public class Planet : MonoBehaviour
{
    float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 5f * speed * Time.deltaTime,0 );
    }
}
