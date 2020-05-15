using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    Animator animDoor;
    public bool dentro = false;
    bool puerta = false;
   
    void Start()
    {
        animDoor = GetComponent<Animator>();
    }


    void Update()
    {
        if(dentro && Input.GetKeyDown(KeyCode.J) )
        {
            puerta = !puerta;
        }
        if (puerta)
        {
            animDoor.SetBool("IsOpen", true);
        }
        else
        {
            animDoor.SetBool("IsOpen", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        dentro = false;
    }
}
