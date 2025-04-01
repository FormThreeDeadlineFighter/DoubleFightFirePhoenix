using Unity.VisualScripting;
using UnityEngine;

public class Enemy_1 : IEnemy
{
    private void Start()
    {
        m_Name = "章魚小怪";
        m_EnemyHP = 10;
        m_AttackPower = 1;
    }
    float m_EnemyShootTime = 3f; //攻擊間隔 3 秒
    
    void FixedUpdate()
    {   
        //章魚存活時間       
        m_EnemyLeaveTime -=Time.deltaTime;
        if(m_EnemyLeaveTime <= 0)
        {
            Leave();
            m_EnemyLeaveTime = 15f;
        }
        //攻擊間隔
        m_EnemyShootTime -=Time.deltaTime;
        if(m_EnemyShootTime <= 0)
        {
            Attack();
            m_EnemyShootTime = 3f;
        }
        
    }
    public override void Attack()
    {        
        Debug.Log("開始射擊"); 
        Instantiate(
        m_EnemyBullet,
        transform.position + new Vector3(0,0,-5),
        transform.rotation);    
           
    }
    //章魚自然死亡
    public void Leave()
    {      
        Destroy(gameObject);
    }
    
    //被子彈擊中
    private void OnTriggerEnter(Collider other)
    {
        IBullet _bullet = other.GetComponent<IBullet>();
        // 判斷來撞(或進入Trigger)的物件是否有子彈標籤
        if (other.CompareTag("Bullet"))
        {
            m_EnemyHP -= _bullet.damage;

            if(m_EnemyHP <=0)
            {
                Destroy(gameObject);
            }     
            
        }
    }
    

}
