using UnityEngine;
using UnityEngine.UI;
public class ISceneState
{
    //狀態名稱
    private string _StateName = "ISceneState";
    public string StateName
    {
        get {return _StateName;}
        set {_StateName = value;}
    }

    //控制者
    protected SceneStateController _Controller = null;

    //建構者
    public ISceneState (SceneStateController Controller)
    {
        _Controller = Controller;
    }

    //開始
    public virtual void StateBegin()
    {}

    //結束
    public virtual void StateEnd()
    {}

    //更新
    public virtual void StateUpdate()
    {}

    public override string ToString()
    {
        return string.Format("[I_SceneState: StateName = {0}]",StateName);
    }

    protected void BindButton(string buttonName, UnityEngine.Events.UnityAction callback)
    {
        GameObject obj = GameObject.Find(buttonName);
        if (obj != null)
        {
            Debug.Log($"✅ 找到 {buttonName}");
            Button btn = obj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(callback);
            }
            else
            {
                Debug.LogError($"物件 {buttonName} 沒有 Button 組件！");
            }
        }
        else
        {
            Debug.LogError($"找不到名為 {buttonName} 的按鈕！");
        }
    }

}
