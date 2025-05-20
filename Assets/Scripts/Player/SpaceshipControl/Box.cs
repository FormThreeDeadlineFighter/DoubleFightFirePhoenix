using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    //Ship HP
    [SerializeField] float _boxHealth;
    //BoxHP
    public float BoxHealth
    {
        get { return _boxHealth; }
        private set
        {
            if (BoxHealth <= 0)
            {
                BoxHealth = 0;
            }
            else
            {
                BoxHealth = value;
            }
        }
    }
    
    public static Box current;

    public event Action OnPlayerHurt;

    private void Awake()
    {
        current = this;
    }

    public void PlayerHurt(int damage)
    {
        if (OnPlayerHurt != null)
        {
            _boxHealth -= damage;
            OnPlayerHurt();
        }
    }
}
