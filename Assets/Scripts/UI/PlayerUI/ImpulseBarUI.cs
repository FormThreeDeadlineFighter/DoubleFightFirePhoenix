using UnityEngine;

public class ImpulseBarUI : MonoBehaviour
{
    [SerializeField] GameObject player; 
    PlayerControl pc;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
