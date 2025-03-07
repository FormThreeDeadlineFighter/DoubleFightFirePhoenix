using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateController : IStateController
{   
    [SerializeField] IPlayerState[] _playerStates;
    private Animator _animator;
    private Rigidbody _rb;
    private SpaceshipController _shipController;
    
    public string PlayerName;


    private void Awake()
    {
        _animator = this.transform.GetComponent<Animator>();
        _shipController = this.transform.parent.GetComponent<SpaceshipController>();
        _rb = this.transform.parent.GetComponent<Rigidbody>();
        PlayerName = this.transform.name;

        _stateTable = new Dictionary<System.Type, IState>(_playerStates.Length);

        foreach(IPlayerState state in _playerStates)
        {
            state.Initialize(this, _animator, _shipController, _rb);
            _stateTable.Add(state.GetType(), state);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
        SetState(_stateTable[typeof(PlayerState_Idle)]);
    }

}
