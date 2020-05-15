using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float range = 3f;
    public float timeAttack = 1f; //Tiempo que tarda en atacar mi enemigo

    private bool playerInRange;

    private BoxCollider armAttack;
    private Animator anim;
    public GameObject player;
    public AudioClip[] clip;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameManager.instance.Player;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    { 
        AttackEnemy();
    }
    void AttackEnemy()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }

    IEnumerator Attack()
    {
        if(playerInRange && !GameManager.instance.GameOver)
        {
            anim.Play("Attack");

            audioSource.Stop();
          audioSource.PlayOneShot(clip[0]);
            yield return new WaitForSeconds(timeAttack);           
        }
        yield return null;
        StartCoroutine(Attack());
    }
}
