using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    //box HP
    [SerializeField] float _boxHealth;
    //box mix hp
    [SerializeField] float _maxHealth;
    [SerializeField] Transform[] playersPosition = new Transform[2];
    //BoxHP
    public float BoxHealth
    {
        get { return _boxHealth; }

        private set
        {
            if (_boxHealth > _maxHealth)
            {
                _boxHealth = _maxHealth;
            }
            else if (BoxHealth < 0)
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
    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 player1dir = playersPosition[0].position;
        Vector3 player2dir = playersPosition[1].position;

        Vector3 dir = player1dir - player2dir;
        this.transform.position = dir / 2;
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
