using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public abstract class IEnemy : MonoBehaviour
{
    
    public string m_characterName; //角色名字
    public int m_AttackPower; //攻擊力
    public int m_EnemyHP; //角色血量
    public float m_EnemyLeaveTime; //敵人自然死亡時間
    public float m_EnemyShootTime; //敵人攻擊間隔時間
    public GameObject m_EnemyBullet; //敵人的子彈
    public TextMeshPro m_HP;
    public void Die() => Destroy(gameObject); //敵人死亡
    public void MoveForward() => transform.Translate(Vector3.forward * 200 * Time.deltaTime);  //敵人前進  
    public GameObject player;
    
    // 強制所有敵人子類別實作「攻擊行為」
    public abstract void Attack(GameObject player);

    //碰撞判定
    protected void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Find player");
            player = other.gameObject;                 
        }
        
        // 判斷來撞(或進入Trigger)的物件是否有子彈標籤
        if (other.TryGetComponent<IBullet>(out IBullet _bullet))
        {
            Debug.Log("hit");
            m_EnemyHP -= _bullet.damage;
            m_HP.text = "HP : " + m_EnemyHP;
            if (m_EnemyHP <= 0)
            {
                Die();
            }
        }
    }
}
