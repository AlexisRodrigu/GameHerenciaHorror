using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] GameObject ghost;
    private FPSController player;
    public GameObject scream;

    private void Start()
    {
        //gst = GetComponent<Ghost2>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           // Desactivando al player
            player.enabled = false;

            ghost.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        scream.SetActive(false);
        Destroy(gameObject);
    }


}
