using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Controls;

public abstract class ICharacter
{
    protected string m_Name = ""; //名稱
    protected GameObject m_GameObject = null; // 顯示的Unity模型    
    //建構者
    public ICharacter()
    {

    }
    //設定Unity模型
    public void SetGameObject(GameObject theGameObject)
    {
        m_GameObject = theGameObject;
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
       
}
