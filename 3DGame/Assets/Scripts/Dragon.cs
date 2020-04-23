using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour
{
    [Header("移動速度"), Range(1, 1000)]
    public float speed = 300;
    [Header("虛擬搖桿")]
    public Joystick joy;
    [Header("攻擊冷卻時間")]
    public float cd = 1;
    [Header("延遲生成火球時間")]
    public float delayFire = 0.5f;
    [Header("火球")]
    public GameObject fireBall;
    [Header("火球移動速度"), Range(1, 5000)]
    public float speedFireBall = 300;
    [Header("攻擊力"), Range(1, 5000)]
    public float attack = 35;

    // 第一種寫法：需要欄位
    // public Transform tra;

    /// <summary>
    /// 動畫控制器
    /// </summary>
    private Animator ani;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 第一種寫法
        // tra.Translate(0, 0, 1);
        // Time.deltaTime 一禎的時間
        // Input.GetAxis("Vertical"); - WS 上下
        // Input.GetAxis("Horizontal"); - AD 左右
        // 水平：Horizontal

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // 第二種寫法：僅限於 Transform
        transform.Translate(speed * Time.deltaTime * h, 0, speed * Time.deltaTime * v);

        float joyV = joy.Vertical;
        float joyH = joy.Horizontal;

        transform.Translate(speed * Time.deltaTime * joyH, 0, speed * Time.deltaTime * joyV);

        Vector3 pos = transform.position;       // 取得飛龍座標
        pos.x = Mathf.Clamp(pos.x, 30, 70);     // 數學.夾住(值，最小，最大)
        pos.z = Mathf.Clamp(pos.z, 20, 30);
        transform.position = pos;               // 飛龍座標 = 夾住座標
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        timer += Time.deltaTime;                // 計時器 遞增

        if (timer >= cd)                        // 如果 計時器 >= 冷卻
        {
            timer = 0;                          // 計時器 歸零
            ani.SetTrigger("攻擊觸發");          // 動畫控制器.設定觸發器("參數名稱")

            StartCoroutine(DelayFireBall());    // 啟動協程
        }
    }

    /// <summary>
    /// 延遲生成火球
    /// </summary>
    private IEnumerator DelayFireBall()
    {
        yield return new WaitForSeconds(delayFire);             // 延遲生成火球

        Vector3 posFire = transform.position;                   // 火球座標 = 飛龍座標
        posFire.z += 4.2f;                                      // 微調 Z 軸
        posFire.y += 2.2f;

        GameObject temp = Instantiate(fireBall, posFire, Quaternion.identity);    // 生成(物件，座標，角度)

        temp.AddComponent<Ball>();                  // 暫存火球.添加元件<球>()
        temp.GetComponent<Ball>().damage = attack;  // 暫存火球.取得元件<球>().傷害值 = 攻擊力

        // Quaternion.identity Unity 角度類型 - 零角度

        temp.GetComponent<Rigidbody>().AddForce(0, 0, speedFireBall);
    }

    private void Start()
    {
        // 取得元件<泛型>()
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }
}
