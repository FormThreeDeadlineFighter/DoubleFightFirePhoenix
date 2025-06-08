using System.Collections.Generic;
using UnityEngine;

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
    PlayerState_Idle idleState;
    PlayerState_Move moveState;
    PlayerState_Shooting shootState;
    
    #endregion

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerControl = GetComponent<PlayerControl>();
        _rb = GetComponent<Rigidbody>();
        _weaponManager = GetComponent<WeaponManager>();

    
        idleState = ScriptableObject.CreateInstance<PlayerState_Idle>();
        moveState = ScriptableObject.CreateInstance<PlayerState_Move>();
        shootState = ScriptableObject.CreateInstance<PlayerState_Shooting>();

        _playerStates = new IPlayerState[] {idleState, moveState, shootState};
        
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
