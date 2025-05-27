using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int damage;
    void Start()
    {
        
    }
    private void HurtPlayer()
    {
        Destroy(this);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Player"))
        {
            Box.current.OnPlayerHurt += HurtPlayer;
            Box.current.PlayerHurt(damage);
            Box.current.OnPlayerHurt -= HurtPlayer;
        }
    }
}
