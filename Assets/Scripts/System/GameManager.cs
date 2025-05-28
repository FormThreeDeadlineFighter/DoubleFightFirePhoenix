using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas UI;
    [SerializeField] GameObject loseUI;
    bool isGameOver = false;
    
    void Update()
    {
        if(!isGameOver && Box.current.BoxHealth <= 0)
        {
            isGameOver = true;
            Instantiate(loseUI, UI.transform);
            Time.timeScale = 0f;       
        }
    }
    
}
