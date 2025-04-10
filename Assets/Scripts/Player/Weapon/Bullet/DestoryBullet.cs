using UnityEngine;

public class DestoryBullet : MonoBehaviour
{
    
    protected float lifetime = 2f; //自然死亡時間
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject , lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
