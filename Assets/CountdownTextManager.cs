using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTextManager : MonoBehaviour
{
    public TMP_Text[] countdownTexts; // 倒计时文本数组：0 = 3, 1 = 2, 2 = 1, 3 = START
    public float textDisplayDuration = 1.0f; // 每个文本显示持续时间（1秒）
    public float textFadeDuration = 0.5f; // 每个文本淡出持续时间（0.5秒）

    void Start()
    {
        // 确保倒计时文本数组不为空
        if (countdownTexts == null || countdownTexts.Length == 0)
        {
            Debug.LogError("倒计时文本数组未分配或为空");
            return;
        }

        // 确保所有文本对象都已正确分配
        foreach (var text in countdownTexts)
        {
            if (text == null)
            {
                Debug.LogError("倒计时文本数组中的某个文本未分配");
                return;
            }
        }

        StartCountdown();
    }

    public void StartCountdown()
    {
        StartCoroutine(ShowCountdownTexts());
    }

    public IEnumerator ShowCountdownTexts()
    {
        foreach (TMP_Text currentText in countdownTexts)
        {
            if (currentText != null && currentText.gameObject != null)
            {
                currentText.gameObject.SetActive(true); // 显示当前文本

                yield return new WaitForSecondsRealtime(textDisplayDuration); // 等待显示时间

                float elapsedTime = 0f;
                while (elapsedTime < textFadeDuration)
                {
                    if (currentText != null)
                    {
                        float alpha = Mathf.Lerp(1f, 0f, elapsedTime / textFadeDuration);
                        currentText.alpha = alpha;
                    }
                    elapsedTime += Time.unscaledDeltaTime;
                    yield return null;
                }

                if (currentText != null && currentText.gameObject != null)
                {
                    currentText.gameObject.SetActive(false); // 隐藏当前文本
                }
            }
            else
            {
                Debug.LogWarning("currentText or its GameObject is null.");
            }
        }

        // 倒计时结束后执行其他逻辑（如通知其他对象或者触发事件）
        CountdownFinished?.Invoke(); // 触发倒计时结束的事件
    }

    // 声明倒计时结束的事件
    public delegate void CountdownFinishedHandler();
    public static event CountdownFinishedHandler CountdownFinished;

    // 在 OnDestroy 中取消订阅事件，以防止内存泄漏
    void OnDestroy()
    {
        CountdownFinished = null;
    }
}
