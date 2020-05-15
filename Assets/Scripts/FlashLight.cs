using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private bool turnOn;
    [SerializeField] private Light light;

    private AudioSource audio;
    public AudioClip clickSound;
    void Start()
    {
        light = GetComponent<Light>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        TurnOn();
    }
    void TurnOn()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //turnOn = true;
            turnOn = !turnOn;
            {
                if (turnOn)
                {
                    light.enabled = false;
                    audio.PlayOneShot(clickSound);
                }
                else
                {
                    light.enabled = true;
                    audio.PlayOneShot(clickSound);
                }
            }
        }
    }

}
