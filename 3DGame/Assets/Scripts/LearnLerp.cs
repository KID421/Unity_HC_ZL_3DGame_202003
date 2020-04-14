using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    public float A = 0, B = 100;

    public Vector2 v2A = new Vector2(0, 0);
    public Vector2 v2B = new Vector2(1000, 1000);

    private void Start()
    {
        //print(Mathf.Lerp(A, B, 0.5f));
    }

    private void Update()
    {
        A = Mathf.Lerp(A, B, 0.5f);

        v2A = Vector2.Lerp(v2A, v2B, 0.1f);
    }
}
