using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] gb = new GameObject[10];
    Vector3[] pinsIntitialPos = new Vector3[10];
    Vector3[] pinRotation = new Vector3[10];
    public GameObject cam, ball;
    Vector3 camInitPos, ballInitPos;
    Vector3 ballInitRot;
    public Transform[] pinSpawner = new Transform[10];
    public GameObject pinsToSpawn;
    int availableShots = 10;
    int shotTaken = 0;
    int[] scoreBoard = new int[10];
    [HideInInspector] public bool deactivateThis = false;
    int[] frameScore = new int[5];
    int scoreIndexer = 0;
    public ComponentController cm;

    private void Start()
    {
        PinsAssigner();
        InitialPositionStore();
    }


    void PinsAssigner()
    {
        gb = GameObject.FindGameObjectsWithTag("Pin");

    }

    void InitialPositionStore()                           //contains all the intial postion value;
    {
        camInitPos = cam.transform.position;
        ballInitPos = ball.transform.position;
        ballInitRot = ball.transform.rotation.eulerAngles;
    }

    bool AllPinDown()                                   //check wether all pins are down;
    {
        bool allPinDown = false;
        if (gb.Length == 0)
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
     
        for (int i = 0; i < 10; i++)
        {
            Instantiate(pinsToSpawn, pinSpawner[i]);
        }
       
    }



    void ConditionForArranging()
    {
        int downPinCounter;
        if(ball.transform.position.y <= -15)
        {
            
            downPinCounter =  DestroyDownPins();
            BallArranger();
            ScoreCounter(downPinCounter);
            shotTaken = shotTaken + 1;
            availableShots = availableShots - 1;
            //print("shot taken" + shotTaken);
            print("available shots" + availableShots);
        }
    }

   

  int  DestroyDownPins()                                    //will destroy all the down pins;
    {
        int downPinCounter = 0;
        for (int i = 0; i < gb.Length; i++)
        {
            if (gb[i].transform.rotation.x != 0)
            {
                downPinCounter++;
                Destroy(gb[i]);
            }
        }
        return downPinCounter;
    }




   void BallArranger()                                         //will arrange my ball and camera to its initial position;
    {
        cam.transform.position = camInitPos;
        ball.transform.position = ballInitPos;
        ball.transform.rotation = Quaternion.Euler(ballInitRot);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
    }



    void ScoreCounter(int downPinCount)
    {
       
        if(downPinCount < 10)
        {
            scoreBoard[scoreIndexer] = downPinCount;
            scoreIndexer++;
        }
        else
        {
            scoreBoard[scoreIndexer] = 10;
           // print(scoreBoard[i]);
            scoreBoard[scoreIndexer + 1] = 0;
            scoreIndexer = scoreIndexer + 2;
            availableShots = availableShots - 1;
        }
    }




    void DestroyStandingPinsAfterFameComplete()
    {
        for(int j = 0; j < gb.Length; j++)
        {
            Destroy(gb[j]);
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        PinsAssigner();
        bool allIsDown = AllPinDown();

       if (allIsDown)
        {
            PinArranger();
        }
        

        if (availableShots > 0)
        {
            ConditionForArranging();
          /*  if(availableShots < 10)
            {
                if (availableShots % 2 == 0)
                {
                    DestroyStandingPinsAfterFameComplete();
                    PinArranger();
                }
            }*/
           

        }

        else
        {
            ConditionForArranging();
            for (int j = 0; j < 10; j++)
            { 
                print(scoreBoard[j]);
            }
            deactivateThis = true;
            cm.ControllerDeactivator();
        }
        
    }
    
}
