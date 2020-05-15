using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public GameObject rope;

   public AudioClip audio;

   private AudioSource sound;

    public void Start()
    {
        sound = GetComponent<AudioSource>();
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            rope.SetActive(true);
            sound.PlayOneShot(audio);
        }
    }
 
}
