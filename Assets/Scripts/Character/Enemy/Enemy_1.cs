using Unity.VisualScripting;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    string m_Name = "章魚小怪";
    int m_EnemyHP = 10;
    int m_AttackPower = 1;
    float m_EnemyLeaveTime = 15f;
    int m_Enemy1num = 0;
    float offsetMin = -4f;
    float offsetMax = 4f;
    
    void FixedUpdate()
    {   
        //章魚存活時間       
        m_EnemyLeaveTime -=Time.deltaTime;
        if(m_EnemyLeaveTime == 0)
        {
            Leave();
        }
        //章魚生成
        if(m_Enemy1num <= 2)
        {
            EnemyRespawn();
            m_Enemy1num++;
        }
        
    }
    public void Attack()
    {        
        Debug.Log("開始射擊");     
           
    }
    public void Leave()
    {      
        Destroy(this.gameObject);
    }
    public void EnemyRespawn()
    {
        //章魚生成        
        Instantiate(
            this,
            new Vector3(Random.Range(offsetMin,offsetMax),0,10),
            transform.rotation
            );
    }

}
