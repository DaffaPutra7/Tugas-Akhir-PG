using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Pengaturan Kecepatan")]
    public float moveSpeed = 5f;

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

        // --- PERBAIKAN DISINI ---
        // Kita butuh jarak positif (Absolut) dari kamera ke objek (Z=0)
        float distanceToCamera = Mathf.Abs(mainCamera.transform.position.z);

        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distanceToCamera));
        // ------------------------

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        // Pastikan setting Input System sudah "Both" (Lihat Langkah 2 di bawah)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        // Logika Clamp sekarang aman karena screenBounds sudah benar
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = viewPos;
    }
}