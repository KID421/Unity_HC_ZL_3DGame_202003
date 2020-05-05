using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dragon : MonoBehaviour
{
    public static float cd = 0.5f;
    public static float hp = 100;

    [Header("移動速度"), Range(1, 1000)]
    public float speed = 300;
    [Header("虛擬搖桿")]
    public Joystick joy;
    [Header("延遲生成火球時間")]
    public float delayFire = 0.5f;
    [Header("火球")]
    public GameObject fireBall;
    [Header("火球移動速度"), Range(1, 5000)]
    public float speedFireBall = 300;
    [Header("攻擊力"), Range(1, 5000)]
    public float attack = 35;
    [Header("血條")]
    public Image hpBar;

    private GameManager gm;

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
        temp.GetComponent<Ball>().type = "玩家";

        // Quaternion.identity Unity 角度類型 - 零角度

        temp.GetComponent<Rigidbody>().AddForce(0, 0, speedFireBall);
    }

    /// <summary>
    /// 吃掉加速藥水
    /// </summary>
    private void EatPropCd()
    {
        cd -= 0.5f;
        cd = Mathf.Clamp(cd, 0.6f, 100);
    }

    /// <summary>
    /// 吃掉補血藥水
    /// </summary>
    private void EatPropHp()
    {
        StartCoroutine(HpBarEffect());
    }

    /// <summary>
    /// 血條增加特效
    /// </summary>
    private IEnumerator HpBarEffect()
    {
        float hpAdd = hp + 20;

        while (hp < hpAdd)
        {
            hp++;
            hp = Mathf.Clamp(hp, 0, 100);
            hpBar.fillAmount = hp / 100;
            yield return null;              // null 一禎
        }
    }

    /// <summary>
    /// 血條減少特效
    /// </summary>
    private IEnumerator HpBarEffectSub(float damage)
    {
        float hpSub = hp - damage;
        if (hpSub <= 0) Dead();

        while (hp > hpSub)
        {
            hp--;
            hp = Mathf.Clamp(hp, 0, 100);
            hpBar.fillAmount = hp / 100;
            yield return new WaitForSeconds(0.01f);              // null 一禎
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收到的傷害值</param>
    public void Damage(float damage)
    {
        if (gm.passLv) return;
        StartCoroutine(HpBarEffectSub(damage));
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        gm.Lose();
    }

    private void Start()
    {
        // 取得元件<泛型>()
        ani = GetComponent<Animator>();
        hpBar.fillAmount = hp / 100;

        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (ani.GetBool("死亡開關")) return;
        Move();
        Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "加速藥水")
        {
            EatPropCd();
            Destroy(other.gameObject);
        }
        if (other.tag == "補血藥水")
        {
            EatPropHp();
            Destroy(other.gameObject);
        }
    }
}
