using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PassLevelCanvas : MonoBehaviour
{
    public Button returnToMenuButton; // 返回主選單按鈕
    public Button goToNextSceneButton; // 前往下一場景按鈕

    void Start()
    {
        // 確保 PassLevelCanvas 在遊戲開始時是隱藏的
        gameObject.SetActive(false);

        // 添加按鈕點擊事件
        returnToMenuButton.onClick.AddListener(ReturnToMenu);
        goToNextSceneButton.onClick.AddListener(LoadNextScene);

        // 根據當前場景設置按鈕
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SetNextSceneButton(currentSceneIndex);
    }

    // 根据当前场景设置下一场景按钮的可见性和点击事件
    void SetNextSceneButton(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 1: // 第一關
            case 2: // 第二關
                goToNextSceneButton.gameObject.SetActive(true);
                break;
            default:
                goToNextSceneButton.gameObject.SetActive(false);
                break;
        }
    }

    // 當碰到 finish cube 時顯示 PassLevelCanvas
    public void ShowPassLevelCanvas()
    {
        gameObject.SetActive(true);
    }

    // 返回主選單
    void ReturnToMenu()
    {
        SceneManager.LoadScene(0); // 返回主選單場景 0
    }

    // 加載下一個場景（根據當前場景來判斷）
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
