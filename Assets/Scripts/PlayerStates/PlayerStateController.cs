using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    IPlayerState _playerState = null;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        _playerState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _playerState.PhysicsUpdate();
    }
}
