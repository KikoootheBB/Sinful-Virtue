using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrath : AIMovement
{
    //Timer para o estado ativo da wrath
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(7);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Debug.Log("active");
            ActiveWrath();
        }
    }
    void ActiveWrath()
    {
        agent.destination = (target.position);
        speed = 22.0f;
        StartCoroutine(Timer());
        return;
    }
}
