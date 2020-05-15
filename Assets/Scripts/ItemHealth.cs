using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    private GameObject player;
    private PlayerLife playerLife;
 
    void Start()
    {
        player = GameManager.instance.Player;
        playerLife = player.GetComponent<PlayerLife>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && Input.GetButton("Interactuar"))
        {
            playerLife.UpHealth();
            Destroy(gameObject);
        }
    }
}
