using UnityEngine;

public class DestoryBullet : MonoBehaviour
{
    public float lifetime = 2f;
    void Start()
    {
        Destroy(gameObject , lifetime);
    }
    //擊中敵人
    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
