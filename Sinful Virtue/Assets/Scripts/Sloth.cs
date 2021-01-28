using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sloth : AIMovement
{
    //Ativação do Sin
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            GotoNextPoint();
        }
    }
    new void GotoNextPoint()
    {
        Debug.Log("active");
        agent.destination = target.position;
        activated = true;
    }
}


