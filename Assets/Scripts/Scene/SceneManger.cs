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
        SceneManager.LoadScene("StageScene");
    }
    public void ReturnStage()
    {
        Debug.Log("重整");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 替換成關卡圖
    }
    public void Stage()
    {
        int index = PlanetManger.currentIndex;
        SceneManager.LoadScene($"Level {index}");
    }
    public void NextStage()
    {
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
}
