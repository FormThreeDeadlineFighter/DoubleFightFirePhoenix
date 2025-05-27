using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goat : MonoBehaviour
{
    [SerializeField] Canvas UI;
    [SerializeField] GameObject winUI;

    private void OnTriggerEnter(Collider other)
    {
        OnPlayerWin();
    }
    void OnPlayerWin()
    {
        Instantiate(winUI, UI.transform.position, UI.transform.rotation, UI.transform);
        Time.timeScale = 0f;
        StartCoroutine(SwitchScene(3));
    }

    IEnumerator SwitchScene(int time)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("StageScene");
    }
}
