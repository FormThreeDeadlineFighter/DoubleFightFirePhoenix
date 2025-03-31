using UnityEngine;
public class DestoryBullet : MonoBehaviour
{
    public float lifetime = 2f;
    //自然死亡時間
    void Start()
    {
        Destroy(gameObject , lifetime);
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
