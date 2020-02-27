using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    PlayerMover playerMover;

    [SerializeField]
    GameObject cloud;
    CloudMover cloudMover;

    [SerializeField]
    CameraController cameraController;

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
        cameraController.SetTarget(player);
        playerMover = player.GetComponent<PlayerMover>();
        cloudMover = cloud.GetComponent<CloudMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LB"))
        { ControlTargetChange(); }

        switch (controlTarget)
        {
            case ControlTarget.Player:
                playerMover.PlayerUpdate();
                break;

            case ControlTarget.Cloud:
                cloudMover.CloudUpdate();
                break;

            default:
                Debug.Log("variable:ControlTarget is corrupted!!");
                break;
        }
    }

    void ControlTargetChange()
    {
        switch (controlTarget)
        {
            case ControlTarget.Player:
                controlTarget = ControlTarget.Cloud;
                cameraController.SetTarget(cloud);
                break;

            case ControlTarget.Cloud:
                controlTarget = ControlTarget.Player;
                cameraController.SetTarget(player);
                break;
        }
    }
}
