using System.Collections;
using UnityEngine;

public class AirBarrier : MonoBehaviour
{
    public float barrierDuration = 3f; // 空气墙存在的时间

    void Start()
    {
        // 确保空气墙开始时就被激活
        gameObject.SetActive(true);
        
        StartCoroutine(ActivateAndDeactivateBarrier());
    }

    IEnumerator ActivateAndDeactivateBarrier()
    {
        yield return new WaitForSeconds(barrierDuration); // 等待一定时间

        gameObject.SetActive(false); // 禁用空气墙
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("碰到了空气墙"); // 在控制台中输出碰撞信息，方便测试
            // 不做任何其他操作，因为空气墙只是阻挡，不会触发游戏结束
        }
    }
}
