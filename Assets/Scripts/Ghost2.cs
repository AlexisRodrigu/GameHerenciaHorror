using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost2 : MonoBehaviour
{

    private FPSController player;
    public  GameObject scream;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }
    void Update()
    {
        StartCoroutine(KillOnAnimationEnd());
    }
    private IEnumerator KillOnAnimationEnd()
    {
    
        //yield return new WaitForSeconds(8.12f);

        yield return new WaitForSeconds(8.12f);
        scream.SetActive(true);

        player.enabled = true;
       
        Destroy(gameObject);
    }
}
