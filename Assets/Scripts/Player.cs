using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float score = 0;
    public GameObject projectilePrefab;
    public float fireCooldown = 0.5f;
    private float fireTimer = 0f;

    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;
    [SerializeField] TextMeshProUGUI scoretext;
    Rigidbody2D rb;
    SpriteRenderer sR;

    Vector2 input;
    Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        //rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        velocity = input.normalized * moveSpeed;

        if (input.sqrMagnitude > .01f)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                if (input.x > 0)
                    sR.sprite = spriteRight;
                else if (input.x < 0)
                    sR.sprite = spriteLeft;
            }
        }
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && fireTimer >= fireCooldown)
        {
            Fire();
            fireTimer = 0f;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.Translate(0, 0, 0);
        }
    }
    void Fire()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mouseWorldPos - transform.position);
        direction.z = 0f; // Z 제거
        direction.Normalize();

        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * 100f; // 총알 속도
    }
}
