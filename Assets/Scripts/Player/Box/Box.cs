using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxSensor))]
public class Box : MonoBehaviour
{
    //box HP
    [SerializeField] float _boxHealth;
    //box mix hp
    [SerializeField] float _maxHealth;
    [SerializeField] List<Transform> playersPosition = new List<Transform>();

    private BoxSensor boxSensor;
    
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

        boxSensor = GetComponent<BoxSensor>();
    }
    private void Update()
    {
        playersPosition.Clear();
        foreach (GameObject gameObject in boxSensor.Objects)
        {       
            playersPosition.Add(gameObject.transform);
        }
        
        FollowPlayer();
    }
    

    private void FollowPlayer()
    {
        Vector3 dir = Vector3.forward;
        
        if(playersPosition.Count() == 2)
        {
            Vector3 player1dir = playersPosition[0].position;
            Vector3 player2dir = playersPosition[1].position;     
            dir = (player1dir + player2dir) / 2f; 
        }
        transform.position =  dir ;
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
