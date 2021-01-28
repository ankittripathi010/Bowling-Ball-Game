using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gm;
     Vector2 direction;
     bool ballInMotion;
    [SerializeField] Animator anim;
    Rigidbody rb;
    [SerializeField] float forceMagnitude = 20;
    [SerializeField] float xSensitivity = 0.03f;


    void AndroidInput(bool isBallMoving)
    {
       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
              
                if (isBallMoving == false)
                  {
                  
                     rb.velocity = Vector3.forward * forceMagnitude;
                 
                  }
            }
       
        }
    }


    bool IsBallMoving()
    {
        bool isBallMoving;
        if(rb.velocity.normalized == Vector3.forward)
        {
            isBallMoving = true;
        }
        else
        {
            isBallMoving = false;
        }

        return isBallMoving;
    }



    void  SideCotroller(bool ballInMotion)
    {
        if(ballInMotion)
        {
            float xInput = Input.acceleration.x;
            transform.Translate(xInput*xSensitivity, 0, 0);

        }
      
    }

   bool DisableSideContoller()
    {
        bool offIt;
        if(transform.position.z > 9f)
        {
            offIt = true;
        }
        else
        {
            offIt = false;
        }

        return offIt;
    }



    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        bool isBallMoving = IsBallMoving();
        AndroidInput(isBallMoving);
        bool off = DisableSideContoller();
        if(off == false)
        {
            SideCotroller(isBallMoving);
        }
      
 
    }
}
