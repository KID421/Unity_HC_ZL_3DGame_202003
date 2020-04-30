using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("移動速度"), Range(0.1f, 30f)]
    public float speed;

    /// <summary>
    /// 移動方法
    /// </summary>
    private void MoveMethod()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        MoveMethod();
    }
}
