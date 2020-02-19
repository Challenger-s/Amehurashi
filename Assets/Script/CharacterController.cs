using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    CharacterMover characterMover;
    InputController inputController;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.characterMover = GetComponent<CharacterMover>();
        this.inputController = GetComponent<InputController>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }
}
