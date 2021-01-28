using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinDestroyer : MonoBehaviour
{
   


    void DestroyFunction()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.x != 0)
        {
            Invoke("DestroyFunction", 10);
        }
    }
}
