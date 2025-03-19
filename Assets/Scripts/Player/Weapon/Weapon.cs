using UnityEngine;

public enum ENUM_Weapon
{
    Null = 0,
    Gun_1 = 1,
    Gun_2 = 2,
    Gun_3 = 3,
    Max,
}
public class Weapon
{
    // 數值
    protected ENUM_Weapon m_emWeapon = ENUM_Weapon.Null; // 類型 
    protected int m_AtkValue = 0; //攻擊力
    protected int m_AtkRange = 0; //攻擊距離
    protected int m_AtkPlusValue = 0; //額外加成值

    public Weapon(ENUM_Weapon Type , int AtkValue , int AtkRange)
    {
        m_emWeapon = Type;
        m_AtkValue = AtkValue;
        m_AtkRange = AtkRange;
    }
    public ENUM_Weapon GetWeaponType()
    {
        return m_emWeapon;
    }
    // 攻擊目標
    public void Fire(ICharacter theTarget)
    {

    }
    //設定額外攻擊力
    public void SetAtkPlusValue(int AtkPlusValue)
    {
        m_AtkPlusValue = AtkPlusValue;
    }
    //顯示子彈特效
    public void ShowBulletEffect(Vector3 TargetPosition , float LineWidh , float DisplayTime)
    {

    }
    //顯示槍口特效
    public void ShowShootEffect()
    {

    }
    //顯示音效
    public void ShowSoundEffect()
    {
        
    }
}
