using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Trigger sem er � f�nast�nginni � endanum
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        // ef �� labbar a� f�nast�nginni �� kemur �� vannst skj�rinn
        if (controller != null)
        {
            SceneManager.LoadScene(2);
        }
        
    }
}
