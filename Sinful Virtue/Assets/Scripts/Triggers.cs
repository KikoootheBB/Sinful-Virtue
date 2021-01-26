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
            GameObject lightArea = GameObject.FindGameObjectWithTag("Light");
            CircleCollider2D lightcol = lightArea.GetComponent<CircleCollider2D>();
            other.gameObject.SetActive(false);
            lightcol.radius += 1.5f;
        }
        if (other.gameObject.CompareTag("Sloth") || other.gameObject.CompareTag("Wrath"))
        {
            SceneManager.LoadScene("Hub");
        }
    }
  }
