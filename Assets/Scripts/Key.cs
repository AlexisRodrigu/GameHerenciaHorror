using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
  public bool dentro= false;
  public  Renderer rend;
    void Update()
    {
        Comprobar();
    }

    void Comprobar()
    {
        if (dentro && Input.GetKeyDown(KeyCode.J))
        {
            rend.enabled = (false);
            Door.tienesLlave = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = true;
        }
    }
}
