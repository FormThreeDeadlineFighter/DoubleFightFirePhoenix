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
        _animator = this.transform.GetComponent<Animator>();
        _playerControl = this.transform.GetComponent<PlayerControl>();
        _rb = this.transform.GetComponent<Rigidbody>();
        _weaponManager = this.transform.GetComponent<WeaponManager>();

        _stateTable = new Dictionary<System.Type, IState>(_playerStates.Length);
    
        idleState = ScriptableObject.CreateInstance<PlayerState_Idle>();
        moveState = ScriptableObject.CreateInstance<PlayerState_Move>();
        shootState = ScriptableObject.CreateInstance<PlayerState_Shooting>();

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
