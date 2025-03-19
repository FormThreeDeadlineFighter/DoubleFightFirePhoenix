using UnityEngine;

public class ImpulseBarUI : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    PlayerStateController pc;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = player.GetComponent<PlayerStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(1, pc.ImpulseBar / 100 ,1);
    }
}
