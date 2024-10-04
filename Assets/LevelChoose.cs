using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChoose : MonoBehaviour
{
    public Button level1Button; // 第一关按钮
    public Button level2Button; // 第二关按钮
    public Button level3Button; // 第三关按钮

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);

        // 设置按钮是否可交互（根据解锁的关卡数）
        level1Button.interactable = unlockedLevel >= 1;
        level2Button.interactable = unlockedLevel >= 2;
        level3Button.interactable = unlockedLevel >= 3;
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex); // 加载指定索引的关卡
    }
}
