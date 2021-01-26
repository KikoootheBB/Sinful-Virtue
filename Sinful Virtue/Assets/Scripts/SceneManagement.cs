using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Vector3 SpotInNextRoom;
    void OnTriggerEnter2D(Collider2D other)
    {
        //Dependendo da porta é carregado o mapa correspondente 
        if (other.gameObject.CompareTag("Player")&& tag == "Door 3")
        {
            SceneManager.LoadScene("Wrath");
            OnDoorEntered();
        }
        if (other.gameObject.CompareTag("Player") && tag == "Door 7")
        {
            SceneManager.LoadScene("Sloth");
            OnDoorEntered();
        }
        if (other.gameObject.CompareTag("Player") && tag == "Hub Door")
        {
            SceneManager.LoadScene("Hub");
            OnDoorEntered();
        }
        //Atribui uma nova posição ao player após este passar pela porta (Fonte: https://answers.unity.com/questions/1594415/changing-character-position-when-changing-scenes.html)
        void OnDoorEntered()
        {
            GameManager.Instance.SpawnLocation = SpotInNextRoom;
        }
    }
}