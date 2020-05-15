using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlood : MonoBehaviour
{
    public GameObject bloodGO;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Bullet>() != null)
        {
            Debug.Log(collision.collider.name);
            bloodGO = Instantiate(bloodGO, transform.position, transform.rotation);
        }
    }
}
