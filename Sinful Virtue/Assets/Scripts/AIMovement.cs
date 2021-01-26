using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [SerializeField] Transform[] movePoints;
    public Transform target;
    private int destPoint = 0;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoBraking = false;
        GotoNextPoint();
    }
    void Update()
    {
        //Quando estiver próximo do objetivo atual escolher outro ponto
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
    //Timer para o estado ativo da wrath
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
    }
    //Ativação do estado "ativo" dos Sins
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light") && gameObject.CompareTag("Sloth"))
        {
            Debug.Log("active");
            ActiveSloth();
        }
        if (other.gameObject.CompareTag("Light") && gameObject.CompareTag("Wrath"))
        {
            Debug.Log ("active");
            ActiveWrath();
        }
    }
    //Escoler um ponto aleatório da lista de pontos
    void GotoNextPoint()
    {
        if (movePoints.Length == 0)
            return;
        destPoint = Random.Range(0, movePoints.Length);
        agent.destination = movePoints[destPoint].position;
    }
    void ActiveSloth()
    {
        agent.destination = (target.position);
    }
    void ActiveWrath()
    {
        agent.destination = (target.position);
        agent.speed = 22.0f;
        StartCoroutine(Timer());
        return;
    }

}
