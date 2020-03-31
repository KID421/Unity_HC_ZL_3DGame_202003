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

    // 修飾詞 類型 名稱 指定 值;
    // 公開 public 允許所有文件存取：顯示在屬性面板
    public int score = 10;
    // 私人 private 僅限使類別存取：隱藏在屬性面板
    private int speed = 99;

    public Camera cam;  // 定義一個類行為 Camera 的物件，名稱是 cam

    // GameObject 儲存階層面板或專案內的預製物
    public GameObject cube;
    public GameObject sphere;

    private void Start()
    {
        // 使用靜態成員
        // 靜態屬性 Static Properties
        // 取得 Get：類別.靜態屬性
        print(Random.value);
        // 設定 Set：類別.靜態屬性 = 值
        // 不能設定 Read Only 的屬性
        Time.timeScale = 1f;

        // 使用靜態方法 Static Methods
        print(Random.Range(0.1f, 99.9f));   // 第一個多載
        print(Random.Range(100, 500));      // 第二個多載

        // 練習一：
        // 使用靜態成員 - 取得數學 PI 3.141592：Mathf (Math Function)

        print(Mathf.PI);

        // 練習二：
        // 使用靜態方法 - 數學.絕對值 -999：Mathf

        print(Mathf.Abs(-999));

        // 靜態：類別.成員
        print("攝影機數量：" + Camera.allCamerasCount);
        // 非靜態：物件.成員
        print(cam.depth);

        // 取得 非靜態屬性
        print(cube.layer);
        print(sphere.layer);

        // 設定 非靜態屬性
        cube.layer = 3;
        sphere.layer = 4;

        // 使用 非靜態方法
        cube.SetActive(true);
        sphere.SetActive(false);
    }
}
