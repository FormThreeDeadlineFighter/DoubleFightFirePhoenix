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
        GameObject[] allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        BindButton("Stage1Button", () => OnStageButtonClick(1));
        BindButton("Stage2Button", () => OnStageButtonClick(2));
        BindButton("Stage3Button", () => OnStageButtonClick(3));
        BindButton("Stage4Button", () => OnStageButtonClick(4));
        BindButton("Stage5Button", () => OnStageButtonClick(5));
    }
    public void ReturnStage()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName); // 替換成關卡圖
    }
    public void NextStage()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;  // 例如 Level1-1
        Debug.Log(currentSceneName);
        // 以 '-' 分割：得到 ["Level1", "1"]
        string[] parts = currentSceneName.Split('-');
        
        if (int.TryParse(parts[1], out int levelNumber))
        {
            levelNumber++;
            string nextSceneName = parts[0] + "-" + levelNumber;
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("轉換失敗：不是有效的數字 -> " + parts[1]);
        }
    }
    protected void OnStageButtonClick(int stageNumber)
    {
        Debug.Log($"點擊了第 {stageNumber} 關！");
        // 你可以根據 stageNumber 載入對應關卡：
        string stageSceneName = $"Level1-{stageNumber}";
        SceneManager.LoadScene($"Level1-{stageNumber}");
    }
    protected void BindButton(string buttonName, UnityEngine.Events.UnityAction callback)
    {
        GameObject obj = GameObject.Find(buttonName);
        if (obj != null)
        {
            Debug.Log($"✅ 找到 {buttonName}");
            Button btn = obj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(callback);
            }
            else
            {
                Debug.LogError($"物件 {buttonName} 沒有 Button 組件！");
            }
        }
        else
        {
            Debug.LogError($"找不到名為 {buttonName} 的按鈕！");
        }
    }
}
