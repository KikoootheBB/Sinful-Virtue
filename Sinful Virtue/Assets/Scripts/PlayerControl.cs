using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;


    void Start()
    //Atribui a ao player a posição inicial definida no GameManager (Fonte: https://answers.unity.com/questions/1594415/changing-character-position-when-changing-scenes.html) 
    {
        transform.position = GameManager.Instance.SpawnLocation;
    }
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

     //Recepção dos inputs e criação do vetor de direção
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    //Aplicação da velocidade conforme o vetor de direção
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

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
}
