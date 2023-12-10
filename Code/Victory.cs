using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Trigger sem er á fánastönginni í endanum
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        // ef þú labbar að fánastönginni þá kemur þú vannst skjárinn
        if (controller != null)
        {
            SceneManager.LoadScene(2);
        }
        
    }
}
