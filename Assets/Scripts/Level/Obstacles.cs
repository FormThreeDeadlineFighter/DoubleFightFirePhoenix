using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] int damage;
    void Start()
    {
        
    }
    private void HurtPlayer()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Box.current.OnPlayerHurt += HurtPlayer;
            Box.current.PlayerHurt(damage);
            Box.current.OnPlayerHurt -= HurtPlayer;
        }
    }
}
