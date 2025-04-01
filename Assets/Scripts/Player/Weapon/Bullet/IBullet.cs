using UnityEngine;

public class IBullet : MonoBehaviour
{
    protected int speed = 100; //子彈移動速度
    protected float lifetime = 2f; //自然死亡時間
    protected int damage ;//子彈傷害
    void Start()
    {
        Destroy(gameObject , lifetime);
    }  
    
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
}
