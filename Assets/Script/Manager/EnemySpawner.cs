using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f; // Muncul tiap 2 detik

    // Area muncul (X) agar acak kiri-kanan
    public float xLimit = 2.5f;

    void Start()
    {
        // Ulangi fungsi "SpawnEnemy" setiap sekian detik
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // 1. Tentukan posisi X secara acak (Random)
        float randomX = Random.Range(-xLimit, xLimit);

        // 2. Posisi Y ada di atas layar (misal 6)
        Vector2 spawnPos = new Vector2(randomX, 6f);

        // 3. Munculkan Musuh (Instantiate)
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}