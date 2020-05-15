using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] GameObject gunGO;
    [SerializeField] GameObject flashLightGO;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
     }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Player")
        {
            Gun.iHaveGun = true;
            inventory.amount = inventory.amount + 1;
            Destroy(gameObject);

        }
    }
}
