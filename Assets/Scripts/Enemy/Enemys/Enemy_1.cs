using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_1 : IEnemy
{
    private void Start()
    {
        m_characterName = "章魚小怪";     //名字
        m_EnemyHP = 10;         //血量
        m_AttackPower = 1;      //攻擊力
        m_EnemyLeaveTime = 150f; //小怪死亡時間
        m_EnemyShootTime = 3f;  //攻擊間隔
                
        m_HP.text = "HP : " + m_EnemyHP;

    }
    
    void Update()
    {   
        /*//章魚存活時間       
        m_EnemyLeaveTime -=Time.deltaTime;
        if(m_EnemyLeaveTime <= 0)
        {
            Die();
            m_EnemyLeaveTime = 15f;
        }*/

        //攻擊間隔
        m_EnemyShootTime -=Time.deltaTime;
        if(m_EnemyShootTime <= 0)
        {
            Attack(player);
            m_EnemyShootTime = 3f;
        }       
               
    }
    public override void Attack(GameObject player)
    {        
        Debug.Log("開始射擊");                
              
        if(player != null)
        {
            // 計算從敵人到玩家的方向
            Vector3 direction = (transform.position - player.transform.position).normalized;

            // 讓子彈面向玩家（注意：因為你的子彈用的是 transform.forward 前進，所以要朝向玩家）
            Quaternion rotation = Quaternion.LookRotation(direction);

            // 產生子彈並給它正確的朝向
            Instantiate(m_EnemyBullet, transform.position, rotation);      
        }
    }
 
    
}
