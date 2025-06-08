using UnityEngine;

public class Bullet_1 : IBullet
{
    private void HurtObjects()
    {     
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {            
            HurtObjects();
        }
    }

    
}
