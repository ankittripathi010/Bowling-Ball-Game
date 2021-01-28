using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    
    public GameManager gm;
    public Camera cam;
    public Controller controller;

    
 /*   void InvokingHere()
    {
        gm.DestroyDownPins();
       // gm.BallArranger();
    }

   IEnumerator CallingTheArranger()                 
    {
                                                             These both are causing lag in arranging ball;
        gm.DestroyDownPins();
        gm.BallArranger();
        yield return null;
    }*/

    void CamFollowerDeactivator()
    {
        if (cam.transform.position.z > 7)
        {
            cam.GetComponent<CamFollower>().enabled = false;
            // StartCoroutine(CallingTheArranger());
        }
        else
        {
            cam.GetComponent<CamFollower>().enabled = true;
        }
    }

    void GameManagerDeactivator()
    {

        if (gm.deactivateThis)
        {
            gm.enabled = false;
        }
    }

    public void ControllerDeactivator()
    {
        controller.enabled = false;
    }
    void FixedUpdate()
    {
        CamFollowerDeactivator();
        GameManagerDeactivator();
      
    }
}
