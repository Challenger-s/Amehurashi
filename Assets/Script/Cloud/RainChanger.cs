using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainChanger : MonoBehaviour
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
        float vertical = Input.GetAxis("CameraVertical");

        if (Input.GetButton("RB"))
        {
            var emission = particleSystem.emission;
            if (vertical == 0)
            {
                emission.rateOverTime = 0;
            }

            rainfall = -vertical * 60;
            emission.rateOverTime = rainfall;      
        }
    }

    public float Rainfall()
    {
        return rainfall;
    }
}
