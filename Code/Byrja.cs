using UnityEngine;
using UnityEngine.SceneManagement;

public class Byrja : MonoBehaviour
{
    // Fall sem loadar leiknum notað í öllum tökkum í upphafssenu lokasenu og dauður senu
    public void StartMain()
    {
        Debug.Log("LoadScene method called");
        SceneManager.LoadScene(1);
    }
}
