using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour
{
    //"Apanhar" as virtudes ou os pecados
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Virtue"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Sin"))
        {
            SceneManager.LoadScene("Hub");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Info"))
        {
            other.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Info"))
        {
            other.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


}