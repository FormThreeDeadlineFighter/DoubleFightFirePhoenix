using UnityEngine;

public class DestoryBullet : MonoBehaviour
{
    public float lifetime = 2f;
    void Start()
    {
        Destroy(gameObject , lifetime);
    }
}
