﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverMiddle : MonoBehaviour
{
    ParticleSystem particleSystem;

    [SerializeField]
    RiverMiddle riverMiddle;

    [SerializeField]
    bool riverEnd = false;

    float flow = 0;

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
        this.flow = flow;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!riverEnd)
        {
            riverMiddle.Flowed(this.flow);
        }
    }


}
