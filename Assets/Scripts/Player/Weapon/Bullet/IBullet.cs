using UnityEngine;

public class IBullet : MonoBehaviour
{
    public int speed = 100; //子彈移動速度
    protected float lifetime = 2f; //自然死亡時間
    public int damage ;//子彈傷害
    void Start()
    {
        Destroy(gameObject , lifetime);
    }  
    
    void Update()
    {
        //子彈往前飛行
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    //擊中物體
    private void OnTriggerEnter(Collider other)
    {
        //擊中敵人        
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        //擊中玩家
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
