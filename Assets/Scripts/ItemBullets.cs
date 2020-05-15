using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBullets : MonoBehaviour
{

    public Gun gun;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Input.GetButton("Interactuar"))
        {
            gun.Recharge();
            Destroy(gameObject);
        }
    }
}
