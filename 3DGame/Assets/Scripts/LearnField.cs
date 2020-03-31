using UnityEngine;

public class LearnField : MonoBehaviour
{
    // 定義欄位 field
    // 存放遊戲資料
    // 修飾詞 類型 名稱 (指定 值) ；
    // 不指定：數值型為 0、布林值 false、字串 ""
    public int speed = 10;
    public float jump = 50.5f;
    public string prop = "小刀";
    public bool complete = true;

    // Header 標題
    // Tooltip 提示
    // Range 範圍：int、float
    [Header("武器"), Tooltip("這是角色的主要武器。")]
    public string weapon = "BB槍";
    [Header("分數"), Range(0, 100)]
    public int score = 60;
}
