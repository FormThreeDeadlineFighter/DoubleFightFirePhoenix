using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject SpaceShip; //玩家
    public GameObject EnemyObject_1; //小怪1_章魚
    Enemy enemy_1 = new Enemy();

    public int m_Enemy1num = 0;
    float offsetMin = -4f;
    float offsetMax = 4f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        //enemy_1.Attack();

        if(m_Enemy1num <=2)
        {
            EnemyRespawn();
            m_Enemy1num++;
        }       
    }
    public void EnemyRespawn()
    {
        //章魚生成        
        Instantiate(
            EnemyObject_1,
            SpaceShip.transform.position + new Vector3(Random.Range(offsetMin,offsetMax),0,10),
            transform.rotation
            );
    }
    public void Fire()
    {
        
    }
    public void EnemyLeave()
    {        
        Destroy(EnemyObject_1);
    }
}
