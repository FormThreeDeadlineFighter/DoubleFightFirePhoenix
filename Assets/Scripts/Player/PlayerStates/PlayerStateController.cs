using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerControl), typeof(WeaponManager))]
public class PlayerStateController : IStateController
{   
    [SerializeField] IPlayerState[] _playerStates;
    [SerializeField] string _name;
    private Animator _animator;
    private Rigidbody _rb;
    private PlayerControl _playerControl;
    private WeaponManager _weaponManager; 
    
    

    private void Awake()
    {
        _animator = this.transform.GetComponent<Animator>();
        _playerControl = this.transform.GetComponent<PlayerControl>();
        _rb = this.transform.GetComponent<Rigidbody>();
        _weaponManager = this.transform.GetComponent<WeaponManager>();

        _stateTable = new Dictionary<System.Type, IState>(_playerStates.Length);
      
        foreach(IPlayerState state in _playerStates)
        {
            
            state.Initialize(this, _animator, _playerControl, _rb, _weaponManager, _name);
            _stateTable.Add(state.GetType(), state);
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
        SetState(_stateTable[typeof(PlayerState_Idle)]);
    }
}
