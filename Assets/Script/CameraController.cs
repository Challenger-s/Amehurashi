using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject[] target;
    int targetNum;

    [SerializeField]
    float yMax;
    [SerializeField]
    float yMin;

    [SerializeField]
    GameObject camera;

    float yAngle = 0;
    float xAngle = 0;

    CameraTargetInfo targetInfo;
    Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        targetNum = 0;
        targetInfo = target[targetNum].GetComponent<CameraTargetInfo>();
        targetTransform = target[targetNum].transform;
        camera.transform.position = new Vector3(0, 0, -targetInfo.cameraToTargetDistance);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateCamera();
    }

    void UpdateCamera()
    {
        if (Input.GetButtonDown("LB"))
        {
            ChangeTarget();
        }

        MoveCameraTarget();
        MoveCamera();
    }

    void MoveCameraTarget()
    {
        this.transform.position = targetTransform.position + targetInfo.targetPointFromObject;
    }

    void MoveCamera()
    {
        float horizontal = Input.GetAxis("4th axis");
        float vertical = Input.GetAxis("5th axis");
        yAngle += vertical;
        xAngle += horizontal;

        if(yAngle > yMax) { yAngle = yMax; }
        if(yAngle < yMin) { yAngle = yMin; }

        this.transform.eulerAngles = new Vector3(yAngle,xAngle,0);
    }

    void ChangeTarget()
    {
        if (targetNum + 1 == target.Length)
        {
            targetNum = 0;
        }
        else
        {
            targetNum++;
        }

        targetInfo = target[targetNum].GetComponent<CameraTargetInfo>();
        targetTransform = target[targetNum].transform;
        xAngle = 0;
        yAngle = 0;
    }

    public float GetYRotation()
    {
        return transform.rotation.eulerAngles.y;
    }
}
