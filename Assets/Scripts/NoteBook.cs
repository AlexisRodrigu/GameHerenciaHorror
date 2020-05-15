using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : MonoBehaviour
{
    public bool dentro;
    public Renderer rend;
    public GameObject objetos;

    public GameObject luz;
    public GameObject txt;

    public AudioClip cristal;
    [SerializeField] AudioSource audioS;
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    void Update()
    {
        Activate();
    }
    void Activate()
    {
        if (dentro && Input.GetKeyDown(KeyCode.J))
        {
            rend.enabled = (false);
            objetos.SetActive(true);
            txt.SetActive(true);
            audioS.PlayOneShot(cristal);
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
       
        txt.SetActive(false);
        Destroy(luz,1f);
    }
}
