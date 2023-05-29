using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    
    public float speed;

    public float jumpForce;

    public Obstacles obs;

    private Rigidbody2D rb;

    private Vector2 direction;

    public static bool facingRight;

    private SpriteRenderer rend;

    public DeathScreen deathScreen;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
        facingRight = true;

        direction = new Vector2(1, 0);

        obs.SpawnObstacle();

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        WallBounce();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        transform.Translate(direction.normalized * Time.deltaTime * speed);

        rend.flipX = !facingRight;


    }

    private void WallBounce()
    {
        direction = new Vector2(-direction.x, direction.y);
            facingRight = !facingRight;
            obs.SpawnObstacle();
            GameManager.Instance.AddPoints();
            //AudioManager.instance.Play("nazwa d�wi�ku");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Spike")){
            deathScreen.OnDead();
            gameObject.SetActive(false);
        }
            

        if (collision.name.Contains("Wall"))
        WallBounce();

        if (collision.name.Contains("Banana"))
        {
            
            GameManager.Instance.AddCurrency(1);
            collision.gameObject.SetActive(false);

        }
            
    }
    public void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * jumpForce);
    }
}
