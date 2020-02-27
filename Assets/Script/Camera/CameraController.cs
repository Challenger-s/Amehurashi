using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    float yMax;
    [SerializeField]
    float yMin;

    [SerializeField]
    GameObject camera;

    float yAngle = 0;
    float xAngle = 0;

    GameObject target;
    CameraTargetInfo targetInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateCamera();
    }

    void UpdateCamera()
    {
        MoveCameraTarget();
        MoveCamera();
    }

    void MoveCameraTarget()
    {
        this.transform.position = target.transform.position + targetInfo.targetPointFromObject;
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

    public void SetTarget(GameObject target)
    {
        this.target = target;
        targetInfo = target.GetComponent<CameraTargetInfo>();
        xAngle = 0;
        yAngle = 0;
        this.transform.rotation = Quaternion.identity;
        this.transform.position = target.transform.position + targetInfo.targetPointFromObject;
        camera.transform.position = this.transform.position + new Vector3(0,0,-targetInfo.cameraToTargetDistance);
    }

    public float GetYRotation()
    {
        return transform.rotation.eulerAngles.y;
    }
}
