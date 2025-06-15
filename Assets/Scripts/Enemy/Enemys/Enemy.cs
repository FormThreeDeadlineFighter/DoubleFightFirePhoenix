using UnityEngine;


[RequireComponent(typeof(FollowPlayer))]
public class Enemy : IEnemy
{
    private FollowPlayer follower;
    private Animator animator;

    void Awake()
    {
        follower = transform.GetComponent<FollowPlayer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        m_HP.text = "HP : " + m_EnemyHP;
    }

    void Update()
    {

        //攻擊間隔
        m_EnemyShootTime -= Time.deltaTime;
        if (m_EnemyShootTime <= 0)
        {
            animator.Play("Shoot");
            Attack(Vector3.forward);
            m_EnemyShootTime = 3f;
        }
    }

    void LateUpdate()
    {
        transform.position += Vector3.forward * m_EnemySpeed * Time.deltaTime;
    }

    private void OnValidate()
    {

    }

    protected override void Attack(Vector3 dir)
    {
        Debug.Log("開始射擊");

        // 計算從敵人到玩家的方向
        Vector3 direction = dir.normalized;

        // 讓子彈面向玩家（注意：因為你的子彈用的是 transform.forward 前進，所以要朝向玩家）
        Quaternion rotation = Quaternion.LookRotation(direction);

        // 產生子彈並給它正確的朝向
        Instantiate(m_EnemyBullet, transform.position, rotation);

    }

    protected override void Die() => Destroy(gameObject);

    void OnTriggerEnter(Collider other)
    {
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

    void OnDestroy()
    {
        UIController.current.OnCoinCollect += CoinCollect;
        UIController.current.CoinCollect();
        UIController.current.OnCoinCollect -= CoinCollect;
    }

    void CoinCollect()
    {
        print("coin collect");
    }
}
