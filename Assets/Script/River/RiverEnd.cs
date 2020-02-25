using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverEnd : MonoBehaviour
{
    ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        var emission = particleSystem.emission;
        emission.rateOverTime = 0;
    }

    public void Flowed(float flow)
    {
        var emission = particleSystem.emission;
        emission.rateOverTime = flow;
    }
}
