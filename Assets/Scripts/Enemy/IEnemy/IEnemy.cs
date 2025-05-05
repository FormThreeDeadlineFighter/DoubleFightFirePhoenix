using UnityEngine;
using TMPro;

public abstract class IEnemy : MonoBehaviour
{
    
    [SerializeField] protected string m_EneryName; //角色名字
    [SerializeField] protected int m_AttackPower; //攻擊力
    [SerializeField] protected int m_EnemyHP; //角色血量
    [SerializeField] protected float m_EnemyLeaveTime; //敵人自然死亡時間
    [SerializeField] protected float m_EnemyShootTime; //敵人攻擊間隔時間
    [SerializeField] protected GameObject m_EnemyBullet; //敵人的子彈
    [SerializeField] protected TextMeshPro m_HP;
    
    //敵人死亡
    protected virtual void Die() {}  
    
    // 強制所有敵人子類別實作「攻擊行為」
    protected virtual void Attack(GameObject playerPosition) {}
}
