using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    public int numBullet;
    public int startingBullet;

    public Rigidbody bullet;
    public float velBullet;

    public float timerShoot = 1f;
    public float fireRate = 2.5F;
   [SerializeField] private float nextFire = 0f;
    public bool iHaveBullets = true;

    public GameObject munition;
    public static bool iHaveGun = false;

    public GameObject enemigo;


    private AudioSource audioShoot;
    public AudioClip[] clipsGun;
    void Start()
    {
        audioShoot = GetComponent<AudioSource>();

        if(nextFire >= 10)
        {
            nextFire = 3;
        }
        numBullet = startingBullet;

    }
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (iHaveGun == true)
        {
            {
                if (Input.GetButton("Fire1") && Time.time > nextFire && iHaveBullets == true)
                {
                    nextFire = Time.time + fireRate;

                    AnimGun.anim.SetTrigger("Fire");

                    Rigidbody clone;
                    clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
                    clone.velocity = transform.TransformDirection(Vector3.forward * velBullet);
                    numBullet--;
                    audioShoot.PlayOneShot(clipsGun[0]);
                }
            }
            if (Input.GetButton("Fire1") && numBullet <= 0 && Time.time > nextFire)

            {
                nextFire = Time.time + fireRate;
                iHaveBullets = false;
                audioShoot.Stop();
                audioShoot.PlayOneShot(clipsGun[1]);
            }

            if (numBullet <= 0)
            {
                iHaveBullets = false;
            }
            else
            {
                iHaveBullets = true;
            }
        }
    }

    //Recargar balas
    public void Recharge()
    {
        if(numBullet <= 7  )
        {
            numBullet += 3;
        }
 
    }
}
