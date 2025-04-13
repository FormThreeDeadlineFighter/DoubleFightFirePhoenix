using Unity.VisualScripting;
using UnityEngine;

public class Enemy_1 : IEnemy
{
    private void Start()
    {
        m_Name = "章魚小怪";     //名字
        m_EnemyHP = 10;         //血量
        m_AttackPower = 1;      //攻擊力
        m_EnemyLeaveTime = 15f; //小怪死亡時間
        m_EnemyShootTime = 3f;  //攻擊間隔
                
        m_HP.text = "HP : " + m_EnemyHP;
    }
    
    void FixedUpdate()
    {   
        //章魚存活時間       
        m_EnemyLeaveTime -=Time.deltaTime;
        if(m_EnemyLeaveTime <= 0)
        {
            Die();
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
        Instantiate(m_EnemyBullet,transform.position + new Vector3(0,0,-5),transform.rotation);    
           
    }
    
    //被子彈擊中
    private void OnTriggerEnter(Collider other)
    {
        IBullet _bullet = other.GetComponent<IBullet>();
        // 判斷來撞(或進入Trigger)的物件是否有子彈標籤
        if (other.CompareTag("Bullet"))
        {
            m_EnemyHP -= _bullet.damage;
            m_HP.text = "HP : " + m_EnemyHP;
            if(m_EnemyHP <= 0)
            {
                Die();
            }     
            
        }
    }
    

}
