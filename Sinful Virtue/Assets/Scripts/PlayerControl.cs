using UnityEngine;
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
}
