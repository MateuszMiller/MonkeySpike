using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float speed;

    public float jumpForce;

    public Obstacles obs;

    private Rigidbody2D rb;

    private Vector2 direction;

    public static bool facingRight;

    private SpriteRenderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rend = GetComponent<SpriteRenderer>();

        facingRight = (Random.value > 0.5f);

        if (facingRight)
            direction = new Vector2(1, 0);

        else
            direction = new Vector2(-1, 0);

        obs.SpawnObstacle(5);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * jumpForce);
        }

        transform.Translate(direction.normalized * Time.deltaTime * speed);

        rend.flipX = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Spike"))
            Destroy(gameObject);
        else if (collision.name.Contains("Wall"))
        {
            direction = new Vector2(-direction.x, direction.y);
            facingRight = !facingRight;
            obs.SpawnObstacle(3);
        }
    }
}
