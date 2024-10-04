using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float tiltAngle = 30f;
    public Canvas gameOverCanvas;
    public AirBarrier airBarrier; // 引用空氣墙脚本
    public CountdownTextManager countdownTextManager; // 引用倒计时管理器

    private bool canMove = true; // 是否允許移動
    Vector3 initialPosition; // 初始位置

    void Start()
    {
        initialPosition = transform.position; // 保存初始位置

        // 检查 gameOverCanvas 是否已分配
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
        }
        else
        {
            Debug.LogError("GameOverCanvas 未分配，请在编辑器中分配。");
        }

        // 如果空气墙未赋值，尝试查找场景中的空气墙
        if (airBarrier == null)
        {
            airBarrier = FindObjectOfType<AirBarrier>();
            if (airBarrier == null)
            {
                Debug.LogError("AirBarrier 未分配且在场景中未找到。");
            }
        }

        // 如果找到空气墙，则激活它
        if (airBarrier != null)
        {
            airBarrier.gameObject.SetActive(true);
        }

        // 启动倒计时
        if (countdownTextManager != null)
        {
            countdownTextManager.StartCountdown();
            CountdownTextManager.CountdownFinished += OnCountdownFinished;
        }
        else
        {
            Debug.LogError("CountdownTextManager 未分配，请在编辑器中分配。");
        }
    }

    void OnCountdownFinished()
    {
        // 倒计时结束后，禁用空气墙并允许玩家移动
        if (airBarrier != null)
        {
            airBarrier.gameObject.SetActive(false);
        }
        canMove = true;
        CountdownTextManager.CountdownFinished -= OnCountdownFinished;
    }

    void Update()
    {
        // 如果空气墙激活或不允许移动，不允许移动
        if ((airBarrier != null && airBarrier.gameObject.activeSelf) || !canMove)
        {
            return;
        }

        float xAcceleration = Input.acceleration.x;
        Vector3 movement = new Vector3(xAcceleration, 0f, 1f);
        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.x < -4 || transform.position.x > 4)
        {
            transform.Translate(0f, -10f * Time.deltaTime, 0f);
        }

        if (transform.position.y < -20)
        {
            Time.timeScale = 0;
            if (gameOverCanvas != null)
            {
                gameOverCanvas.enabled = true;
            }
        }
    }

    public void ResetPlayer()
    {
        transform.position = initialPosition; // 重置位置
        Time.timeScale = 1; // 恢复时间缩放为正常

        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false; // 关闭游戏结束面板
        }

        // 确保空气墙在重置玩家时禁用
        if (airBarrier != null)
        {
            airBarrier.gameObject.SetActive(false);
        }

        canMove = true; // 恢復移動
    }

    public void StopMovement()
    {
        canMove = false; // 停止移動
    }
}
