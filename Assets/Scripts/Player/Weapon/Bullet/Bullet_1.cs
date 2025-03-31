using UnityEngine;

public class Bullet_1 : IBullet
{
    
    private void Start()
    {
        
    }
    //擊中物體
    private void OnTriggerEnter(Collider other)
    {
        //擊中敵人        
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
