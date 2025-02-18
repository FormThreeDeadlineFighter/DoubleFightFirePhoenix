using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    private IPlayerState _playerState ;

    private void Awake()
    {
        _playerState = new PlayerState_Idle(this);
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
    public void SwitchState(IPlayerState newState)
    {
        _playerState.ExitState();
        _playerState = newState;
        _playerState.EnterState();
    }
}
