using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    //Ship HP
    [SerializeField] float _shipHealth;
    //Ship moving speed
    [SerializeField] float _shipMoveSpeed;
    // Ship forward speed
    [SerializeField] float _shipforwardSpeed;

    private void Awake()
    {
        
    }

    public void ShipMoveAxesX(float dirX)
    {
        this.transform.Translate(dirX, 0, 0, Space.World);
    }
    
    public void ShipMoveAxesY(float dirY)
    {
        this.transform.Translate(0, dirY, 0, Space.World);
    }

    public void Forward()
    {
        this.transform.Translate(0, 0, _shipforwardSpeed/2 * Time.deltaTime, Space.World);
    }
    
    public void Forward(float forwardSpeed)
    {
        this.transform.Translate(0, 0, forwardSpeed * Time.deltaTime, Space.World);
    }

    /*public void PlayerHurt(int damage)
    {
        if(OnPlayerHurt != null)
        {
            _shipHealth -= damage;
            OnPlayerHurt();
        }
    }*/
}
