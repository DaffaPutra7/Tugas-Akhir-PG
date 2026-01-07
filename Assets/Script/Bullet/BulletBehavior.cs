using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);

        Destroy(gameObject, 3f);
    }
}