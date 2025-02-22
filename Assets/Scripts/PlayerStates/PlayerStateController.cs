using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateController : IStateController
{   
    [SerializeField] IPlayerState[] _playerStates;
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();

        stateTable = new Dictionary<System.Type, IState>(_playerStates.Length);

        foreach(IPlayerState state in _playerStates)
        {
            state.Initialize(this, _animator);
            stateTable.Add(state.GetType(), state);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
        SetState(stateTable[typeof(PlayerState_Idle)]);
    }

}
