using UnityEngine;

[CreateAssetMenu(fileName = "關卡資料", menuName = "KID/關卡資料")]
public class SpawnData : ScriptableObject
{
    public SpawnTime[] spawn;
}

// 序列化：顯示在 Unity 屬性面板 (class 專用)
[System.Serializable]
public class SpawnTime
{
    public string name;
    public float time;
    public SpawnMonster[] monsters;
}

[System.Serializable]
public class SpawnMonster
{
    public GameObject monster;
    public float x;
}