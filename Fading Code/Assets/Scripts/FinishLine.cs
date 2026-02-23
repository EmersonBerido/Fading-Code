using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public int LastSceneIndex = 9;
    public GameObject errorPopupCanvas;
    

    public int nextSceneIndex;

    void Start()
    {
        if (errorPopupCanvas) errorPopupCanvas.SetActive(false);
    }

    public void NextLevel(int sceneIndex, GameObject player = null)
    {
        if (sceneIndex < LastSceneIndex) 
        {
            SceneManager.LoadScene(sceneIndex);
            return;
        }

        // Spawn Error popup UI
        if (errorPopupCanvas) errorPopupCanvas.SetActive(true);

        // Disable player movement
        if (player) player.GetComponent<PlayerControls>().enabled = false;


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the finish line!");

            NextLevel(nextSceneIndex, other.gameObject);
            
        }
    }
}
