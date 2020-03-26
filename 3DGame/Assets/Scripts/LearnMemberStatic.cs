using UnityEngine;

public class LearnMemberStatic : MonoBehaviour
{
    // 定義屬性
    // 語法：類型 名稱 指定 值;
    float a = 0.5f;             // float 浮點數
    int b = 70;                 // int 整數
    bool c = true;              // bool 布林值
    bool d = false;
    string e = "我是字串";       // string 字串

    private void Start()
    {
        // 使用靜態成員
        // 靜態屬性 Static Properties
        // 取得 Get：類別.靜態屬性
        print(Random.value);
        // 設定 Set：類別.靜態屬性 = 值
        // 不能設定 Read Only 的屬性
        Time.timeScale = 1f;
    }
}
