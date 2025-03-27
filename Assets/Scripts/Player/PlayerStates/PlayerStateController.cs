using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateController : IStateController
{   
    [SerializeField] IPlayerState[] _playerStates;
    [SerializeField] string _name;
    private Animator _animator;
    private Rigidbody _rb;
    private SpaceshipController _shipController;
    
    

    private void Awake()
    {
        _animator = this.transform.GetComponent<Animator>();
        _shipController = this.transform.parent.GetComponent<SpaceshipController>();
        _rb = this.transform.parent.GetComponent<Rigidbody>();

        _stateTable = new Dictionary<System.Type, IState>(_playerStates.Length);

        foreach(IPlayerState state in _playerStates)
        {
            state.Initialize(this, _animator, _shipController, _rb, _name);
            _stateTable.Add(state.GetType(), state);
        }
        
        //_impulseBar = 100f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
        SetState(_stateTable[typeof(PlayerState_Idle)]);
    }
}
