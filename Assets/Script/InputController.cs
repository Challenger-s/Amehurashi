using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    KeyCode forward = KeyCode.W;

    [SerializeField]
    KeyCode back = KeyCode.S;

    [SerializeField]
    KeyCode right = KeyCode.D;

    [SerializeField]
    KeyCode left = KeyCode.A;

    float move = 0;
    float steering = 0;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(this.forward))
        {
            this.move = 1;
        }
        else if (Input.GetKey(this.back))
        {
            this.move = -1;
        }
        else
        {
            this.move = 0;
        }

        if (Input.GetKey(this.right))
        {
            this.steering = 1;
        }
        else if (Input.GetKey(this.left))
        {
            this.steering = -1;
        }
        else
        {
            this.steering = 0;
        }

        //this.steering = Input.GetAxis("LeftStickHoraizontal");
        //this.move = Input.GetAxis("LeftStickVertical");

    }

    public float Move()
    {
        return this.move;
    }

    public float Steering()
    {
        return this.steering;
    }
}
