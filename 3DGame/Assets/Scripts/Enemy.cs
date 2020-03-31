using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 這是怪物的血量
    /// </summary>
    [Header("血量")]
    public float hp = 50;

    // 認識屬性 Property
    // 可以設定權限：唯讀、允許所有權限
    // get 取得
    // set 設定
    // 不會顯示在屬性面板上

    // 允許所有權限
    /// <summary>
    /// 攻擊力
    /// </summary>
    public int attack { get; set; }
}
