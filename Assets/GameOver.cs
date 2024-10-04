using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button restartButton; // GameOverCanvas中的重新开始按钮
    public Canvas gameOverCanvas; // 添加一个Canvas引用

    void Start()
    {
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(ButtonOnClick);
        }
        else
        {
            Debug.LogError("重新开始按钮未分配到 GameOver 脚本中");
        }

        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false; // 确保初始时 Canvas 是隐藏的
        }
        else
        {
            Debug.LogError("GameOverCanvas 未分配到 GameOver 脚本中");
        }
    }

    void ButtonOnClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // 获取当前场景的索引
        SceneManager.sceneLoaded += OnSceneLoaded; // 监听场景加载事件
        SceneManager.LoadScene(currentSceneIndex); // 加载当前场景
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Player player = FindObjectOfType<Player>(); // 找到场景中的玩家对象
        if (player != null)
        {
            player.ResetPlayer(); // 重置玩家
        }
        else
        {
            Debug.LogWarning("未找到玩家对象，无法重置。");
        }

        SceneManager.sceneLoaded -= OnSceneLoaded; // 卸载事件
    }
}
