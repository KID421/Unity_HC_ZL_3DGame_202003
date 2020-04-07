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

        // 設定屬性：設定唯讀屬性會造成錯誤
        // enemy2.def = 1;
        // 取得屬性
        print("怪物 2 號的防禦力：" + enemy2.def);
        enemy2.lv = 99;
        print("怪物 2 號的 MP：" + enemy2.mp);

        enemy2.damage = 10;
        print("對怪物 2 造成的傷害：" + enemy2.damage);
    }
}
