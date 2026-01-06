using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // PERBAIKAN: Tambahkan ", Space.World" di belakang
        // Ini memaksa peluru bergerak ke atas layar, tidak peduli pelurunya miring/jungkir balik
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);

        // Hancurkan setelah 3 detik
        Destroy(gameObject, 3f);
    }
}