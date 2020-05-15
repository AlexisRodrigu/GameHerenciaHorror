using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MunitionManager : MonoBehaviour
{
    public GameObject gunGO;
    public Gun gun;
   private TextMeshProUGUI txtNumBullet;

    void Start()
    {
        gun = gunGO. GetComponent<Gun>();
        txtNumBullet = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        NumBullets();
  
    }

    void NumBullets()
    {
        txtNumBullet.text = "10 |" + gun.numBullet;
    }
}
