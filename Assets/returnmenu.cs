using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // 加载主菜单（场景 0）
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
