using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsUI : MonoBehaviour
{
    public GameObject virtue;
    void Update()
    {
        if (virtue.activeInHierarchy == false)
        {
            gameObject.SetActive(false);
        }
    }
}
