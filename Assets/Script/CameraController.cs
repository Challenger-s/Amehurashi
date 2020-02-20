using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    Vector3 camerapos;

    // Start is called before the first frame update
    void Start()
    {
        camerapos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("5th axis");
        float horizontal = Input.GetAxis("4th axis");


        if (!(Input.GetButton("RB")))
        {
           
            transform.RotateAround(this.target.transform.position, Vector3.up, horizontal);
            transform.RotateAround(this.target.transform.position, Vector3.right, -vertical);
        }

        
        //transform.RotateAround(this.target.transform.position, Vector3.up, Input.GetAxis("Mouse X"));
        //transform.RotateAround(this.target.transform.position, Vector3.right, Input.GetAxis("Mouse Y"));

        //ターゲットとの距離
        transform.position = this.target.transform.position - transform.forward * 5f;

        //ターゲットの方に向く
        transform.LookAt(this.target.transform);
    }

    public float GetYRotation()
    {
        return transform.rotation.eulerAngles.y;
    }

}
