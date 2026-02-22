using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float xOffset;
    public GameObject player;

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = new Vector3(player.transform.position.x + xOffset, transform.position.y, transform.position.z);
        // larp the camera to the player position with an offset
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + xOffset, transform.position.y, transform.position.z), Time.deltaTime * 5f);


    }
}
