using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapons/Gun", fileName = "Gun")]
[System.Serializable]
public class Gun : IWeapon
{
    
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void InitializeWeapon()
    {
        
    }
}
