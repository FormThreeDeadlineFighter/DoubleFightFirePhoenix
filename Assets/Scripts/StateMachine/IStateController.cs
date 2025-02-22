using UnityEngine;

public class IStateController : MonoBehaviour
{
    protected IState _state;

    void Start()
    {
        _state.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        _state.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _state.PhysicsUpdate();
    }

    protected void SwitchOn(IState newState)
    {
        _state = newState;
        _state.EnterState();
    }

    public void SwitchState(IState newState)
    {
        _state.ExitState();
        SwitchOn(newState);
    }    
}
