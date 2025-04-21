using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    
    // 強制所有敵人子類別實作「攻擊行為」
    public abstract void Attack();
    private void Start()
    {
        
        
    }
    private void Update()
    {
        
    }

    //玩家靠近
    public bool IsPlayerClose()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float PlayerPos = player.transform.position.z;
            float EnemyPos = transform.position.z;

            return (EnemyPos - PlayerPos <= 800f);
        }

        return false;
    }
    //玩家位置
    public void IsPlayerPos()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
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
