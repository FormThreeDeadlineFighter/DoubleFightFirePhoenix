using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    private int speed ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            speed = 500;
            this.transform.Translate(0,0,speed * Time.deltaTime);
        }
        else
        {
            speed = 10;
            this.transform.Translate(0,0,speed * Time.deltaTime);
        }        
    }
}
