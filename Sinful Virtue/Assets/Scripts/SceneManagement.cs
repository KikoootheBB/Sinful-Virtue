using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (tag == "Door 3")
        {
            SceneManager.LoadScene("Wrath");
        }
        if (tag == "Door 7")
        {
            SceneManager.LoadScene("Sloth");
        }
        if (tag == "Hub Door")
        {
            SceneManager.LoadScene("Hub");
        }
    }
}