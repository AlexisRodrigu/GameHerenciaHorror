using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMat : MonoBehaviour
{
    public Material mat;
    public bool parpadeo = true;
     void Awake()
    {
        StartCoroutine(MaterialParpadeante());

    }

    IEnumerator MaterialParpadeante()
    {
       while (parpadeo)
        {
            yield return new WaitForSeconds(2.0f);

            mat.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(2.0f);
            mat.DisableKeyword("_EMISSION");
            
        }
    }
}



 
