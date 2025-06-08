using UnityEngine;


public class EnemyBullet_1 : IBullet
{
    void Update()
    {
        //子彈向後飛行
        transform.Translate(Vector3.back*speed*Time.deltaTime);
    }
    
    private void HurtPlayer()
    {     
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Box.current.OnPlayerHurt += HurtPlayer;
            Box.current.PlayerHurt(damage);
            Box.current.OnPlayerHurt -= HurtPlayer;
        }
    }
}
