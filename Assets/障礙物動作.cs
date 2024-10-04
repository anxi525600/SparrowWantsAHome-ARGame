using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Canvas gameOverCanvas; // 關聯到 Unity 界面中的 GameOverCanvas

    void Start()
    {
        // 确保 Canvas 最初是隐藏的
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
            Debug.Log("GameOverCanvas 已成功分配并设置为隐藏");
        }
        else
        {
            Debug.LogWarning("gameOverCanvas 未分配到 Barrier 脚本中");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameOverCanvas != null)
            {
                Time.timeScale = 0; // 停止游戏时间
                Debug.Log("碰到了普通障碍物"); // 在控制台中输出碰撞信息，方便测试
                gameOverCanvas.enabled = true; // 显示 GameOverCanvas
            }
            else
            {
                Debug.LogWarning("gameOverCanvas 未分配到 Barrier 脚本中");
            }
        }
    }
}
