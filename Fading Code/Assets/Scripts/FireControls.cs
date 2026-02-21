using System.Collections;
using UnityEngine;

public class FireControls : MonoBehaviour
{
    public GameObject firePrefab;
    public KeyCode fireKey = KeyCode.Space;
    public float spawnOffsetX = 1f;
    private float cooldown = 0.5f; // Time between fires
    private float cooldownTimer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            SpawnFire();
        }
        cooldownTimer += Time.deltaTime; // Increment cooldown timer
    }

    void SpawnFire()
    {
        if (cooldownTimer < cooldown) return; // Still in cooldown, do not spawn fire

        Debug.Log("Fire Spawned");
        Vector2 spawnPosition = transform.position;
        spawnPosition.x += spawnOffsetX * (this.GetComponent<PlayerControls>().facing == PlayerControls.Direction.Right ? 1 : -1);

        GameObject fire = Instantiate(firePrefab, spawnPosition, Quaternion.identity);
        fire.GetComponent<FireBehavior>().CreateFire(this.GetComponent<PlayerControls>().facing == PlayerControls.Direction.Right ? 1 : -1);

        cooldownTimer = 0; // Reset cooldown timer
    }

     
}
