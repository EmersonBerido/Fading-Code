using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the finish line!");

            // Loads next scene in build settings
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            
        }
    }
}
