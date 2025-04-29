using System;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // 場景狀態
    SceneStateController _SceneStateController = new SceneStateController();
    void Awake()
    {
        //場景轉換不會被刪除
        GameObject.DontDestroyOnLoad(this.gameObject);

        //亂數種子
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);

    }
    void Start()
    {
        //設定起始場景
        _SceneStateController.SetState(new StartState(_SceneStateController),"");
    }

    
    void Update()
    {
        _SceneStateController.StateUpdate();
    }
}
