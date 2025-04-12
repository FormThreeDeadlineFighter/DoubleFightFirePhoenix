using UnityEngine;

public class DestoryBullet : MonoBehaviour
{ 
    void Start()
    {
        float lifetime = 4f; //自然死亡時間
        Destroy(gameObject , lifetime);
    }
}
