using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private ISceneState _State;
    private bool _bRunBegin = false;

    public SceneStateController(){}

    //設定狀態
    public void SetState(ISceneState State, string LoadSceneName)
    {
        //Debug.Log("SetState:"+State.ToString());
        _bRunBegin = false ;

        //載入場景
        LoadScene(LoadSceneName);

        //通知前一個場景結束
        if(_State != null)
        {
            _State.StateEnd();
        }
        //設定
        _State = State;
    }
    //載入場景
    private void LoadScene(string LoadSceneName)
    {
        if(LoadSceneName == null || LoadSceneName.Length == 0)
        {
            return;
        }
        SceneManager.LoadScene(LoadSceneName);
        
    }
    //更新
    public void StateUpdate()
    {
        //是否還在載入
        if (!SceneManager.GetActiveScene().isLoaded) return;

        //通知新的State開始
        if(_State != null && _bRunBegin == false)
        {
            _State.StateBegin();
            _bRunBegin = true;
        }
        if(_State != null)
        {
            _State.StateUpdate();
        }
    }
}
