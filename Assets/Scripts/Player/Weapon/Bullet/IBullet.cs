using UnityEngine;

public class IBullet : MonoBehaviour
{
    [SerializeField] protected int speed;//子彈移動速度
    public int damage ;//子彈傷害
    [SerializeField] protected float lifetime;
    void OnEnable()
    {
        Destroy(gameObject , lifetime);
    }
    
    void Update()
    {
        //子彈往前飛行
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
