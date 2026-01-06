using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // 1. Gerak Lurus ke Bawah (World Space)
        // Kita pakai Space.World agar tidak peduli rotasi musuhnya gimana, dia tetap turun ke bawah layar
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);

        // 2. Hancurkan jika keluar layar bawah (Hemat Memori)
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    // 3. Deteksi Tabrakan (Logic Trigger)
    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika yang menabrak memiliki Tag "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Hancurkan Peluru
            Destroy(other.gameObject);

            // Hancurkan Musuh (Diri Sendiri)
            Destroy(gameObject);

            // (Nanti disini kita tambah Script Skor)
        }
        // Jika yang menabrak adalah Player
        else if (other.CompareTag("Player"))
        {
            // Hancurkan Musuh
            Destroy(gameObject);
            // Game Over Logic (Nanti)
            Debug.Log("GAME OVER!");
        }
    }
}