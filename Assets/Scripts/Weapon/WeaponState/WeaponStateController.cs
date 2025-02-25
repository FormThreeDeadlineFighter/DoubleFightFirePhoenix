using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponStateController : IStateController
{ 
    [SerializeField] IWeaponState[] _weaponState;
    private Animator _animator;
    private Rigidbody _rb;
    private SpaceshipController _shipController;


    private void Awake()
    {
        _animator = this.transform.GetComponent<Animator>();
        _shipController = this.transform.GetComponent<SpaceshipController>();
        _rb = this.transform.GetComponent<Rigidbody>();

        _stateTable = new Dictionary<System.Type, IState>(_weaponState.Length);

        foreach(IWeaponState state in _weaponState)
        {
            state.Initialize(this, _animator, _shipController, _rb);
            _stateTable.Add(state.GetType(), state);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
        SetState(_stateTable[typeof(WeaponState_weapon1)]);
    }

}



