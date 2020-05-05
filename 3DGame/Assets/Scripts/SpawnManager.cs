using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("生成資料")]
    public SpawnData data;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < data.spawn.Length; i++)
        {
            yield return new WaitForSeconds(data.spawn[i].time);

            // 注意：迴圈內的迴圈 int 名稱不能衝突
            for (int j = 0; j < data.spawn[i].monsters.Length; j++)
            {
                // 座標
                Vector3 pos = new Vector3(data.spawn[i].monsters[j].x, 13, 70);
                // 角度
                Quaternion qua = Quaternion.Euler(0, 180, 0);
                // 生成
                Instantiate(data.spawn[i].monsters[j].monster, pos, qua);
            }
        }

        yield return new WaitForSeconds(2);
        gm.Win();
    }
}
