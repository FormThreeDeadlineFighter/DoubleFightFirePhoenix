using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Controls;

public abstract class ICharacter
{
    protected string m_Name = ""; //名稱
    protected GameObject m_GameObject = null; // 顯示的Unity模型
    protected NavMeshAgent m_NavAgent = null; // 控制角色移動使用
    protected AudioSource m_Audio = null ; 
    protected string m_IconSpritName = ""; //顯示Icon

    protected bool m_bKilled = false; //是否陣亡
    protected bool m_bCheckKilled = false; //是否確認過陣亡事件
    protected float m_RemoveTimer = 1.5f; //陣亡後是否永遠移除
    protected bool m_bCanRemove = false; //是否可以移除 

    //建構者
    public ICharacter()
    {

    }
    //設定Unity模型
    public void SetGameObject(GameObject theGameObject)
    {
        m_GameObject = theGameObject;
        m_NavAgent = m_GameObject.GetComponent<NavMeshAgent>();
        m_Audio = m_GameObject.GetComponent<AudioSource>();
    }
    //取得Unity模型
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }
    //釋放
    public void Release()
    {
        if(m_GameObject != null)
        {
            GameObject.Destroy(m_GameObject);
        }
    }
    //名稱
    public string GetName()
    {
        return m_Name;
    }
    //設定Icon名稱
    public void SetIconSpriteName(string SpriteName)
    {
        m_IconSpritName = SpriteName;
    }
    //取得Icon名稱
    public string GetIconSpriteName()
    {
        return m_IconSpritName;
    }
}
