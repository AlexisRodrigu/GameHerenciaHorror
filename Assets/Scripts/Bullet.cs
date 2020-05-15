using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage= -5.0f;
    public float timeLife = 1.5f;
    public GameObject bloodGO;

    void Update()
    {
        Destroy(this.gameObject, timeLife);
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<EnemyController>() != null)
        {
            Debug.Log(collision.collider.name);
            bloodGO = Instantiate(bloodGO, transform.position, transform.rotation);
        }
    }
}
