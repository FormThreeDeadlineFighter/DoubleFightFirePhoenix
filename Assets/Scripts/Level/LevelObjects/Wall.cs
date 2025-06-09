using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] int damage;
    void Start()
    {
        
    }
    private void HurtPlayer()
    {
        
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
