using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public void MainGround()
    {
        SceneManager.LoadScene("MainGround"); // 替換成關卡圖
    }
    public void StageScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageScene");
    }
    public void ReturnStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 替換成關卡圖        
    }
    public void Stage()
    {
        Time.timeScale = 1f;
        int index = PlanetManger.currentIndex;
        SceneManager.LoadScene($"Level {index}");        
    }
    public void NextStage()
    {
        Time.timeScale = 1f;
        string currentSceneName = SceneManager.GetActiveScene().name;  // 例如 Level 0
        // 以 ' ' 分割：得到 ["Level", "0"]
        string[] parts = currentSceneName.Split(' ');
        
        if (int.TryParse(parts[1], out int levelNumber))
        {
            levelNumber++;
            string nextSceneName = parts[0] + " " + levelNumber;
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("轉換失敗：不是有效的數字 -> " + parts[1]);
        }
    }
    
    public void LeaveGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
