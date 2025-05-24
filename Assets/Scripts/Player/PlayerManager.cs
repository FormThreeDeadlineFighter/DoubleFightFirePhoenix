using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint1, SpawnPoint2;
    [SerializeField] GameObject Player;
    void Awake()
    {
        Instantiate(Player, SpawnPoint1.position , SpawnPoint1.rotation);
        Instantiate(Player, SpawnPoint2.position , SpawnPoint2.rotation);
    }
}
