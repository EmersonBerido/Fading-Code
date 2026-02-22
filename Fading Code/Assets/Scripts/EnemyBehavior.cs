using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject leftLocation;
    public GameObject rightLocation;
    public float speed = 1f;
    private bool movingRight = true;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

   

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightLocation.transform.position, Time.deltaTime * speed);
            if (transform.position.x >= rightLocation.transform.position.x)
            {
                movingRight = false;
                sr.flipX = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, leftLocation.transform.position, Time.deltaTime * speed);
            if (transform.position.x <= leftLocation.transform.position.x)
            {
                movingRight = true;
                sr.flipX = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle player collision
            Debug.Log("Player hit by enemy!");
            other.GetComponent<PlayerControls>().RespawnPlayer(); //respawn the player on hit
            
        } else if (other.CompareTag("Projectile"))
        {
            Debug.Log("Enemy hit by projectile!");
            Destroy(other.gameObject); // destroy the projectile
            Destroy(transform.parent.gameObject); // destroy the enemy 
        }
    }
}
