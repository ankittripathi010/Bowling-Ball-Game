using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public GameObject gb;
    private Vector3 offset;

    private void Start()
    {
        offset = gb.transform.position - transform.position;
    }

    void Update()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        transform.position = gb.transform.position - offset;
    }
}
