using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerControl), typeof(WeaponManager))]
public class PlayerStateController : IStateController
{   
    [SerializeField] string _name;
    [SerializeField] IPlayerState[] _playerStates;
    private Animator _animator;
    private Rigidbody _rb;
    private PlayerControl _playerControl;
    private WeaponManager _weaponManager; 
    
    #region PlayerStates
    PlayerState_Idle idleState = new PlayerState_Idle();
    PlayerState_Move moveState = new PlayerState_Move();
    PlayerState_Shooting shootState = new PlayerState_Shooting();
    
    #endregion

    private void Awake()
    {
        _animator = this.transform.GetComponent<Animator>();
        _playerControl = this.transform.GetComponent<PlayerControl>();
        _rb = this.transform.GetComponent<Rigidbody>();
        _weaponManager = this.transform.GetComponent<WeaponManager>();

        _stateTable = new Dictionary<System.Type, IState>(_playerStates.Length);
    
        _playerStates = new IPlayerState[] {idleState, moveState, shootState};
      
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
