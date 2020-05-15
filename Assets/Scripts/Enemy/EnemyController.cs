using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lifeEnemy = 15.0f;
    public float distance = 5.0f;

    public Transform player;
    public Transform initial;
    public NavMeshAgent nav;
    private Animator anim;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        ControllerEnemy();
    }
    void ControllerEnemy()
    {
        anim = GetComponent<Animator>();
        //Distancia en la que me ve
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {

            nav.SetDestination(player.position);
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);

        }
       
        if (GameManager.instance.GameOver)
        {  
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);
        }
    }
}

 

