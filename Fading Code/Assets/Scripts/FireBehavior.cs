using UnityEngine;

public class FireBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xVelocity = 10f;
    public float yVelocity = -5f;
    public float lifetime = 2f;

    void Start()
    {
        Invoke("DestroyFire", lifetime); // Destroy the fire after its lifetime expires
    }

    // Update is called once per frame
    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
    }

    void DestroyFire()
    {
        if (gameObject != null) Destroy(gameObject);
    }

    // -1 for left, 1 for right
    public void CreateFire(float direction)
    {
        xVelocity *= direction; // Adjust the x velocity based on the direction
    }
}
