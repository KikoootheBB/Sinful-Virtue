using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Vector3 SpawnLocation = new Vector3(0,0,0);
    //Impede que o objeto Game Manager seja destruido ao carregar uma nova scene (Fonte: https://answers.unity.com/questions/1594415/changing-character-position-when-changing-scenes.html)
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}