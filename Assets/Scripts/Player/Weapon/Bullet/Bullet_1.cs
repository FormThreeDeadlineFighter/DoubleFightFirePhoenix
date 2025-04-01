using UnityEngine;

public class Bullet_1 : IBullet
{
    
    private void Start()
    {
        damage = 2;
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
