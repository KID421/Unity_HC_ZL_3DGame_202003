using UnityEngine;
using UnityEngine.UI;   // 引用 介面 API

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
        print("開始載入...");
    }
}
