using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemy1, enemy2;

    private void Start()
    {
        // 取得欄位
        print(enemy1.hp);
        // 設定欄位
        enemy2.hp = 200;

        // 設定屬性
        enemy1.attack = 999;
        // 取得屬性
        print("怪物 1 號的攻擊力：" + enemy1.attack);
    }
}
