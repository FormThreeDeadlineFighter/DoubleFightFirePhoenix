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
            SpaceshipController.current.OnPlayerHurt += HurtPlayer;
            SpaceshipController.current.PlayerHurt(damage);
            SpaceshipController.current.OnPlayerHurt -= HurtPlayer;
        }
    }
}
