using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainChange : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem;

    float rainfall = 0;

    // Start is called before the first frame update
    void Start()
    {
        var emission = particleSystem.emission;
        emission.rateOverTime = rainfall;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("5th axis");
        var emission = particleSystem.emission;
        emission.rateOverTime = 0;

        if (Input.GetButton("RB"))
        {
            rainfall = -vertical * 60;
            emission.rateOverTime = rainfall;
        }
    }

    public float Rainfall()
    {

        return rainfall;
    }
}
