using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int startLife = 40;
    [SerializeField] private int currentHealth;
    [SerializeField] private float timeSinceLastHit = 0.5f;
    [SerializeField] private float dissapearSpeed = 5f;
   

    public NavMeshAgent nav;
    private float timer = 0f;
    private bool isAlive;
    private Rigidbody rb;
    private CapsuleCollider collide;
    private bool dissapearEnemy = false;
    private Animator anim;
    public GameObject bloodGO;
    public bool alive { get{return isAlive; } }
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        collide = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        isAlive = true;
        currentHealth = startLife;

        
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Die();
       
    }
    void Die()
    {
        if (dissapearEnemy)
        {
            transform.Translate(-Vector3.up * dissapearSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if (other.tag == "Bullet")
            {
                Punch();
                timer = 0f;
                bloodGO = Instantiate(bloodGO, transform.position, transform.rotation);
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Bullet>() != null)
        {

            bloodGO = Instantiate(bloodGO, transform.position, transform.rotation)as GameObject;
            Destroy(bloodGO, 1f);
        }   
    }
    void Punch()
    {
        if (currentHealth > 0)
        {
            currentHealth -= 10;
        }

        if (currentHealth <= 0)
        {
            isAlive = false;
            KillEnemy();
        }
    }
    void KillEnemy()
    {
        collide.enabled = false;
        nav.enabled = false;
        anim.SetTrigger("Die");
        rb.isKinematic = true;
        StartCoroutine(removeEnemy());
    }

 
    IEnumerator removeEnemy()
    {
        yield return new WaitForSeconds(4f);
        dissapearEnemy = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject,1f);
    }

}
