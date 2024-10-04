using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // 按下開始新遊戲按鈕，連接到 Scene 2
    public void StartNewGame()
    {
        // 在這裡設置任何必要的初始遊戲狀態
        PlayerPrefs.SetInt("unlockedLevel", 1);
        PlayerPrefs.Save(); // 确保数据保存

        // 確認 Scene 2 存在後再加載
        if (SceneManager.sceneCountInBuildSettings > 2)
        {
            Debug.Log("加载Scene 2");
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.LogError("Scene 2 不存在或未加載，無法開始新遊戲。");
        }
    }

    // 按下選擇關卡按鈕，連接到 Scene 1
    public void SelectLevel()
    {
        // 確認 Scene 1 存在後再加載
        if (SceneManager.sceneCountInBuildSettings > 1)
        {
            Debug.Log("加载Scene 1");
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogError("Scene 1 不存在或未加載，無法選擇關卡。");
        }
    }

    // 按下離開遊戲按鈕，關閉遊戲
    public void QuitGame()
    {
        // 在退出前確認是否真的要退出
        Debug.Log("離開遊戲");
        Application.Quit();
    }
}
