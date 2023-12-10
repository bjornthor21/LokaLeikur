using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{

    // Trigger sem notaður er í holunni
    void OnTriggerEnter2D(Collider2D other)
    {
        // ef þú dettur í holuna þá loadast þú ert dauður skjárinn
        RubyController controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            SceneManager.LoadScene(3);
        }

    }
}
