using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMover characterMover;
    InputController inputController;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.characterMover = GetComponent<PlayerMover>();
        this.inputController = GetComponent<InputController>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }
}
