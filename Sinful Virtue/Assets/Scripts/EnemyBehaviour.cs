using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    // Velocidade do inimigo
    [SerializeField] float speed;

    // Direções possíveis
    Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    int directionIndex = 0;

    // Direção atual
    [SerializeField] Vector2 currentDir;

    // Distancia do ray ("visão do inimigo")
    [SerializeField] float rayDistance;
    // layers que afetam o raycast
    [SerializeField] LayerMask rayLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        // escolha da direção inicial
        currentDir = directions[directionIndex];
    }
    void Update()
    {
        // raycast
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, currentDir, rayDistance, rayLayer);
        // debug visual para o raycast
        Vector3 endpoint = currentDir * rayDistance;
        Debug.DrawLine(transform.position, transform.position + endpoint, Color.green);

        // if walls and pacman layer are selected, will return true for either
        if (hit2D.collider != null)
        {
            // Caso o raycast encontre uma parede ou outro inimigo, mudar a direção
            if (hit2D.collider.gameObject.CompareTag("Wall"))
            {
                ChangeDirection();
            }
            if (hit2D.collider.gameObject.CompareTag("Sin"))
            {
                ChangeDirection();
            }
            // Caso o raycast encontre o player
            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("Hub");
            }
        }
    }

    //Controlo da direção do inimigo
    void ChangeDirection()
    {
        // Esolha aleatória de uma nova direção
        directionIndex += Random.Range(0, 2) * 2 - 1;

        // Prevenção para evitar que o index ultrapasse 3
        int clampedIndex = directionIndex % directions.Length;

        // Prevenção para evitar que o index se torne negativo
        if (clampedIndex < 0)
        {
            clampedIndex = directions.Length + clampedIndex;
        }

        // Para o inimigo temporáriamente antes de mudar a direção
        rb.velocity = Vector2.zero;

        // Atribuição de uma nova direção
        currentDir = directions[clampedIndex];
    }

    void FixedUpdate()
    {
        // Movimento de acordo com a direção atual
        rb.AddForce(currentDir * speed);
    }
}