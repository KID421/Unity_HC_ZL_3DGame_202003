using UnityEngine;

public class PracticeMember : MonoBehaviour
{
    public SpriteRenderer logo;

    public Transform cam;

    private void Start()
    {
        Cursor.visible = false;

        logo.flipX = true;

        print("去小數點：" + Mathf.Floor(1.23456f));

        cam.Rotate(0, 90, 0);
    }
}
