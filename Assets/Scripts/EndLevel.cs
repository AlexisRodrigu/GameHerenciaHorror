using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameManager gm;
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag== "Player")
        {
            gm.FinalLevel();
            Time.timeScale = 0f;
        }
      
    }
}
