using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    Animator animDoor;
    public bool dentro = false;
    bool puerta = false;
    public static bool tienesLlave = false;

    [SerializeField]
    private GameObject text;

    void Start()
    {
        animDoor = GetComponent<Animator>();

    }

    void Update()
    {
        CheckDoor();
    }

    void CheckDoor()
    {
        if (dentro && Input.GetButton("Interactuar") && tienesLlave)
        {
            puerta = !puerta;
            Destroy(text);
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
        if (other.tag == "Player" && !tienesLlave)
        {
            text.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        dentro = false;

        if (!tienesLlave)
        {

            text.SetActive(false);

        }
    }


}
