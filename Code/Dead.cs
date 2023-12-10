using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{

    // Trigger sem nota�ur er � holunni
    void OnTriggerEnter2D(Collider2D other)
    {
        // ef �� dettur � holuna �� loadast �� ert dau�ur skj�rinn
        RubyController controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            SceneManager.LoadScene(3);
        }

    }
}
