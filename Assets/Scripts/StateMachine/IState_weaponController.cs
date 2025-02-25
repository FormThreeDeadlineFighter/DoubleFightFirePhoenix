using System.Collections.Generic;
using UnityEngine;

public class IState_weaponController : MonoBehaviour
{
    protected IState_weapon _currentState = null;

    protected Dictionary<System.Type, IState_weapon> _stateTable;


    // Update is called once per frame
    void Update()
    {
        _currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        _currentState.PhysicsUpdate();
    }

    protected void SwitchOn(IState_weapon newState)
    {
        _currentState = newState;
        _currentState.EnterState();
    }

    public void SetState(IState_weapon newState)
    {
        if(_currentState != null)
        {
            _currentState.ExitState();
        }

        SwitchOn(newState);
    }    

    public void SetState(System.Type newStateType)
    {
        SetState(_stateTable[newStateType]);
    }
}
