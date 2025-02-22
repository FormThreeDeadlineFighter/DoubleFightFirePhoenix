using System.Collections.Generic;
using UnityEngine;

public class IStateController : MonoBehaviour
{
    protected IState _currentState = null;

    protected Dictionary<System.Type, IState> stateTable;

    // Update is called once per frame
    void Update()
    {
        _currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        _currentState.PhysicsUpdate();
    }

    protected void SwitchOn(IState newState)
    {
        _currentState = newState;
        _currentState.EnterState();
    }

    public void SwitchState(IState newState)
    {
        if(_currentState != null)
        {
            _currentState.ExitState();
        }

        SwitchOn(newState);
    }    

    public void SwitchState(System.Type newStateType)
    {
        SwitchState(stateTable[newStateType]);
    }
}
