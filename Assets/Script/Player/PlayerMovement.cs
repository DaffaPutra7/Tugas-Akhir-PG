using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Pengaturan Kecepatan")]
    public float moveSpeed = 5f;

    [Header("Pengaturan Menembak")]
    public GameObject bulletPrefab; 
    public Transform firePoint;    

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

        // 2. INPUT MENEMBAK 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate (Memunculkan object)
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