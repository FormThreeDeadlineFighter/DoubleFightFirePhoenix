using UnityEngine;


[RequireComponent(typeof(AISensor), typeof(FollowPlayer))]
public class Enemy_1 :  IEnemy
{
    [SerializeField] GameObject player;
     
    private AISensor sensor;
    private FollowPlayer follower;

    void Awake()
    {
        sensor = transform.GetComponent<AISensor>();
        follower = transform.GetComponent<FollowPlayer>();     
    }
    
    private void Start()
    {    
        m_EneryName = "章魚小怪";     //名字
        m_EnemyHP = 10;         //血量
        m_AttackPower = 1;      //攻擊力
        m_EnemyLeaveTime = 150f; //小怪死亡時間
        m_EnemyShootTime = 3f;  //攻擊間隔
       
        m_HP.text = "HP : " + m_EnemyHP;
    }
    
    void Update()
    {    
        player = null;
        if(sensor.Objects.Count > 0)
        {
            player = sensor.Objects[0];
        }   
            
        //攻擊間隔
        m_EnemyShootTime -=Time.deltaTime;
        if(m_EnemyShootTime <= 0 && player != null)
        {
            Attack(player);
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
    
    protected override void Attack(GameObject player)
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
}
