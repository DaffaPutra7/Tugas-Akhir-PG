using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);     
        }

        else if (other.CompareTag("Player"))
        {
            GameOverManager gm = FindFirstObjectByType<GameOverManager>();
            if (gm != null)
            {
                gm.TriggerGameOver();
            }

            Destroy(other.gameObject);

            Destroy(gameObject);
        }
    }
}