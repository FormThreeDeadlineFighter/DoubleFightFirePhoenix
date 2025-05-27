using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas UI;
    [SerializeField] GameObject loseUI;
    
    void Update()
    {
        if(Box.current.BoxHealth <= 0)
        {
            Instantiate(loseUI, UI.transform.position, UI.transform.rotation, UI.transform);
            Time.timeScale = 0f;
            StartCoroutine(SwitchScene(3));        
        }
    }
    
    IEnumerator SwitchScene(int time)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("StageScene", LoadSceneMode.Additive);
        SceneManager.UnloadScene("Level 1");
    }
}
