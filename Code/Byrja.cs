using UnityEngine;
using UnityEngine.SceneManagement;

public class Byrja : MonoBehaviour
{
    // Fall sem loadar leiknum nota� � �llum t�kkum � upphafssenu lokasenu og dau�ur senu
    public void StartMain()
    {
        Debug.Log("LoadScene method called");
        SceneManager.LoadScene(1);
    }
}
