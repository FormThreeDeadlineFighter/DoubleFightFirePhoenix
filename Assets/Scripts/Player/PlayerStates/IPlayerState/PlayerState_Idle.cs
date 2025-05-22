using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
[System.Serializable]
public class PlayerState_Idle : IPlayerState
{
    //進入待機狀態
    public override void EnterState()
    {
        Debug.Log(_name +"進入待機狀態");
    }
     //離開待機狀態
    public override void ExitState()
    {
        Debug.Log(_name +"離開待機狀態");
    }

    public override void LogicUpdate()
    {
        //Debug.Log("玩家在閒置狀態");
        if(_playerControl.IsMoving)
        {
            _controller.SetState(typeof(PlayerState_Move));
        }
        else if (_playerControl.IsShoot)
        {
            _controller.SetState(typeof(PlayerState_Shooting));
        }  
    }

    // 物理相關的更新（如果有的話）
    public override void PhysicsUpdate()
    {
        
        
    }
}
