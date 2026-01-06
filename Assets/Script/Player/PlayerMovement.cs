using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Pengaturan Kecepatan")]
    public float moveSpeed = 5f;

    [Header("Pengaturan Menembak")]
    public GameObject bulletPrefab; // Masukkan Prefab Bullet kesini
    public Transform firePoint;     // Titik keluarnya peluru (Opsional, pakai posisi player juga bisa)

    [Header("Komponen")]
    public Rigidbody2D rb;

    private Vector2 movement;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        Camera mainCamera = Camera.main;
        float distanceToCamera = Mathf.Abs(mainCamera.transform.position.z);
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distanceToCamera));

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        // 1. INPUT GERAK
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 2. INPUT MENEMBAK (Spasi)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // PENTING UNTUK UCP: Instantiate (Memunculkan object)
        // Parameter: (Apa yang dimunculkan, Dimana posisinya, Rotasinya gimana)
        Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}