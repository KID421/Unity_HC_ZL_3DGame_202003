using UnityEngine;

public class Ball : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "怪物")
        {
            other.GetComponent<Monster>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
