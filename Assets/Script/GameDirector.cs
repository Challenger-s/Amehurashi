using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    CameraController CameraController;

    [SerializeField]
    PlayerController PlayerController;

    [SerializeField]
    GameObject[] controlObjects;
    int controlObjectsNum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LB"))
        {
            ChangeControlTarget();
        }
    }

    void ChangeControlTarget()
    {

    }
}
