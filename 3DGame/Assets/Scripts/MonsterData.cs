using UnityEngine;

[CreateAssetMenu(fileName = "怪物資料", menuName = "KID/怪物資料")]
public class MonsterData : ScriptableObject
{
    [Header("血量"), Range(100, 10000)]
    public float hp;
    [Header("攻擊"), Range(10, 1000)]
    public float attack;
    [Header("移動速度"), Range(1, 100)]
    public float speed;
    [Header("補血藥水掉落機率"), Range(0, 1)]
    public float probHp;
    [Header("加速藥水掉落機率"), Range(0, 1)]
    public float probCd;
}
