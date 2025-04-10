using UnityEngine;

public class IBullet : MonoBehaviour
{
    public int speed = 1000;//子彈移動速度
    public int damage ;//子彈傷害
    void Start()
    {
        
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
