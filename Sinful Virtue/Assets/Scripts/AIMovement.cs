using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    [SerializeField] Transform[] movePoints;
    private int destPoint;
    public Transform target;
    public NavMeshAgent agent;
    public float speed;
    public bool activated;
    
    void Start()
    {
        activated = false;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoBraking = false;
        GotoNextPoint();
    }
    void Update()
    {
        agent.speed = speed;
        agent.acceleration = agent.speed;
        //Quando estiver próximo do objetivo atual escolher outro ponto
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (activated)
            {
                agent.enabled = false;
            }
            else
            {
                GotoNextPoint();
            }
        }
    }
    //Escoler um ponto aleatório da lista de pontos
    public virtual void GotoNextPoint()
    {
        if (movePoints.Length == 0)
            return;
        destPoint = Random.Range(0, movePoints.Length);
        agent.destination = movePoints[destPoint].position;
    }
}
    
    