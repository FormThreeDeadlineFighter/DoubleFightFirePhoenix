using UnityEngine;

public class CrosshairControl : MonoBehaviour
{
    [SerializeField] GameObject crossHair;

    SpaceshipController sc;

    Vector2 crossHairPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sc = GetComponentInParent<SpaceshipController>();

        //crossHairPosition = sc.PlayerInput1.PlayerControl.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
