using UnityEngine;

public class Finish : MonoBehaviour
{
    public PassLevelCanvas passLevelCanvas; // 引用 PassLevelCanvas 脚本
    public Player player; // 引用 Player 脚本
    public int nextLevelToUnlock;

    void OnTriggerEnter(Collider other)
    {
        // 检查碰撞的对象是否是玩家
        if (other.CompareTag("Player"))
        {
            // 显示 PassLevelCanvas
            if (passLevelCanvas != null)
            {
                Time.timeScale = 0; // 停止游戏时间
                Debug.Log("碰到了終點"); // 在控制台中输出碰撞信息，方便测试
                passLevelCanvas.ShowPassLevelCanvas(); // 使用 PassLevelCanvas 的显示方法
            }
            else
            {
                Debug.LogError("PassLevelCanvas 未分配到 Finish 脚本中");
            }

            // 停止玩家移动
            if (player != null)
            {
                player.StopMovement();
            }

            // 更新解锁的下一关级别
            UpdateUnlockedLevel();
        }
    }

    // 更新解锁的关卡级别
    void UpdateUnlockedLevel()
    {
        int currentUnlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);
        if (nextLevelToUnlock > currentUnlockedLevel)
        {
            PlayerPrefs.SetInt("unlockedLevel", nextLevelToUnlock);
            Debug.Log($"解锁了关卡 {nextLevelToUnlock}");
        }
        else
        {
            Debug.LogWarning($"下一关解锁级别 {nextLevelToUnlock} 小于或等于当前解锁级别 {currentUnlockedLevel}，未进行解锁更新。");
        }
    }
}
