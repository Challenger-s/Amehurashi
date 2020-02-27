using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTargetChanger : MonoBehaviour
{
    [SerializeField]
    CameraController cameraController;

    [SerializeField]
    PlayerController playerController;

    enum ControlTarget
    {
        Player,
        Cloud,
    }
    ControlTarget controlTarget;

    // Start is called before the first frame update
    void Start()
    {
        controlTarget = ControlTarget.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LB"))
        {
            ControlTargetChange();
        }
    }

    void ControlTargetChange()
    {
        switch (controlTarget)
        {
            case ControlTarget.Player:
                controlTarget = ControlTarget.Cloud;
                break;
            case ControlTarget.Cloud:
                controlTarget = ControlTarget.Player;
                break;
        }
    }
}
