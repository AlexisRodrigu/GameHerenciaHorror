using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGun : MonoBehaviour
{
    public static Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
      
    }
}
