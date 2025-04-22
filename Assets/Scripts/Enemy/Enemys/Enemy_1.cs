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
        
        if (IsPlayerClose())
        {
            //攻擊間隔
            m_EnemyShootTime -=Time.deltaTime;
            if(m_EnemyShootTime <= 0)
            {
                Attack();
                m_EnemyShootTime = 3f;
            }
        }
        
        
    }
    public override void Attack()
    {        
        Debug.Log("開始射擊");         
        IsPlayerPos();        
    }
 
}
