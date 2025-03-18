using UnityEngine;

public abstract class IEnemy : ICharacter
{
    protected int m_AttackPower; //攻擊力
    protected int m_EnemyHP; //角色血量
    protected float m_EnemyLeaveTime; //敵人自然死亡時間
    protected GameObject m_EnemyBullet; //敵人的子彈
    public IEnemy()
    {
        
    }
    // 強制所有敵人子類別實作「攻擊行為」
    public abstract void Attack();

}
