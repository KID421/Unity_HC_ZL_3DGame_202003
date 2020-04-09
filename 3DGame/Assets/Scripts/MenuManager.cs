using UnityEngine;
using UnityEngine.UI;                   // 引用 介面 API
using UnityEngine.SceneManagement;      // 引用 場景管理 API
using System.Collections;               // 引用 系統.集合 API (協程) - 協同程式：非同步處理

public class MenuManager : MonoBehaviour
{
    [Header("載入畫面")]
    /// <summary>
    ///  載入畫面
    /// </summary>
    public GameObject panelLoading;
    [Header("載入畫面文字")]
    /// <summary>
    /// 載入畫面文字
    /// </summary>
    public Text textLoading;
    [Header("載入畫面吧條")]
    /// <summary>
    /// 載入畫面吧條
    /// </summary>
    public Image imgLoading;

    /// <summary>
    /// 開始載入遊戲場景
    /// </summary>
    public void StartLoading()
    {
        panelLoading.SetActive(true);           // 顯示載入畫面

        StartCoroutine(Loading());              // 啟動協程
    }

    /// <summary>
    /// 協程方法：載入
    /// </summary>
    private IEnumerator Loading()
    {
        // SceneManager.LoadScene("關卡1");        // 載入場景
        AsyncOperation ao = SceneManager.LoadSceneAsync("關卡1");

        ao.allowSceneActivation = false;            // 關閉自動載入場景

        // 迴圈 while(布林值) { 當布林值維 true 時執行敘述 }

        while (ao.progress < 1)
        {
            textLoading.text = (ao.progress / 0.9f * 100).ToString("F2") + " %";    // 更新載入文字

            imgLoading.fillAmount = ao.progress / 0.9f;                             // 更新載入吧條

            yield return null;                   // 等待

            // 判斷式 if(布林值) { 當布林值維 true 時執行一次敘述 }
            if (ao.progress == 0.9f)                                                // 如果 進度 = 0.9
            {
                ao.allowSceneActivation = true;                                     // 允許自動載入場景
            }
        }
    }
}
