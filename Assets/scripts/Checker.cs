using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{


    public GameObject[] gb = new GameObject[10];
    Vector3[] pinsIntitialPos = new Vector3[10];
    Vector3[] pinRotation = new Vector3[10];
    public GameObject cam, ball;
    Vector3 camInitPos, ballInitPos;
    Vector3 ballInitRot;
    public Transform[] pinSpawner = new Transform[10];
    public GameObject pinsToSpawn;
    



    private void Start()
    {
        //Instantiate(pinsToSpawn, spawner);
        PinsAssigner();
        InitialPositionStore();
        
      
    }


   void PinsAssigner()
    {
        gb = GameObject.FindGameObjectsWithTag("Pin");
      
    }

   void InitialPositionStore()                           //contains all the intial postion value;
    {
      /*  for(int i = 0;i<gb.Length;i++)
        {
            pinsIntitialPos[i] = gb[i].transform.position;
            pinRotation[i] = gb[i].transform.rotation.eulerAngles;
        }*/
        camInitPos = cam.transform.position;
        ballInitPos = ball.transform.position;
        ballInitRot = ball.transform.rotation.eulerAngles;
    }

   bool AllPinDown()                                   //check wether all pins are down;
    {
        bool allPinDown = false;
        /* bool[] isStanding = new bool[10];
         bool allPinDown = false;
         int counter = 0;

         for(int i = 0; i<gb.Length;i++)
         {
             if (gb[i].transform.rotation.x != 0)
             {
                 isStanding[i] = false;
             }
             else
             {
                 isStanding[i] = true;
             }
         }
         for(int i=0; i<gb.Length;i++)
         {
             if(isStanding[i] == false)
             {
                 counter++;
             }
         }

         if(counter == gb.Length)
         {
             allPinDown = false;
         }
         else
         {
             allPinDown = true;
         }*/

        if(gb.Length == 0)
        {
            allPinDown = true;
        }
        else
        {
            allPinDown = default;
        }

        return allPinDown;
    }


   void PinArranger()
    {
        /* for (int i = 0; i < gb.Length; i++)
         {
             gb[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
             gb[i].transform.position = pinsIntitialPos[i];
             gb[i].transform.rotation = Quaternion.Euler(pinRotation[i]);
         }*/
        for(int i =0;i<10;i++)
        {
            Instantiate(pinsToSpawn, pinSpawner[i]);
        }
       // PinsAssigner();   
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        PinsAssigner();
        bool allIsDown = AllPinDown();
      
        //Invoke("BallArranger", 5);
       // print(allIsDown);
        if (allIsDown)
        {
            //  Invoke("PinArranger", 5);
            PinArranger();
            print("invoked");
        }  
    }



    //function used in other script;

   public void DestroyDownPins()                                    //will destroy all the down pins;
    {
        for(int i = 0; i<gb.Length;i++)
        {
            if(gb[i].transform.rotation.x != 0)
            {
                Destroy(gb[i]);
            }
        }
    }

   public void BallArranger()                                         //will arrange my ball and camera to its initial position;
    {
        cam.transform.position = camInitPos;
        ball.transform.position = ballInitPos;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.rotation = Quaternion.Euler(ballInitRot);
    }

}
