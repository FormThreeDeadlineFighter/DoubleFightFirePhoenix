using Unity.VisualScripting;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    //string m_Name = "章魚小怪";
    //int m_EnemyHP = 10;
    //int m_AttackPower = 1;
    public float m_EnemyLeaveTime = 15f;
    
    void FixedUpdate()
    {   
        //章魚存活時間       
        m_EnemyLeaveTime -=Time.deltaTime;
        if(m_EnemyLeaveTime <= 0)
        {
            Leave();
            m_EnemyLeaveTime = 15f;
        }      
        
    }
    public void Attack()
    {        
        Debug.Log("開始射擊");     
           
    }
    public void Leave()
    {      
        Destroy(gameObject);
    }
    //被子彈擊中
    private void OnTriggerEnter(Collider other)
    {
        // 判斷來撞(或進入Trigger)的物件是否有子彈標籤
        if (other.CompareTag("Bullet"))
        {
            // 做任何你想做的事，這裡是「小怪消失」
            Destroy(gameObject);
            // 或如果你想做特效、扣血等，也可以先做再銷毀
            // e.g. m_EnemyHP -= 10;
            // if(m_EnemyHP <= 0) Destroy(gameObject);
        }
    }
    

}
