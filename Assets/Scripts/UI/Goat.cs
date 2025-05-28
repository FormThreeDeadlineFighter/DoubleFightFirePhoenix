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
        Instantiate(winUI, UI.transform);
        Time.timeScale = 0f;
    }
}
