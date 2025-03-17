using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyBox : MonoBehaviour
{
    public GameObject Enemybox;
    public GameObject Enemy_1;
    public GameObject Enemy_2;
    float offsetMin = -15f;
    float offsetMax = 15f;
    public float timer = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        //章魚生成
        timer -= Time.deltaTime;        
        if(timer <=0)
        {
            // 生成隨機數量的敵人 (例如 1 ~ 5 隻之間)
            int randomCount = Random.Range(1, 6);
            for (int i = 0; i < randomCount; i++)
            {
                EnemyRespawn();
            }
            // 重置計時器
            timer = 15f;            
        }
    }
    private void EnemyRespawn()
    {
        //章魚生成        
        Instantiate(
            Enemy_1,
            Enemybox.transform.position + new Vector3(Random.Range(offsetMin,offsetMax),Random.Range(offsetMin,offsetMax),7),
            transform.rotation
            );
    }    

}
