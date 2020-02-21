using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverMiddle : MonoBehaviour
{
    ParticleSystem particleSystem;

    [SerializeField]
    RiverMiddle riverMiddle;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Flowed(float flow)
    {
        var emission = particleSystem.emission;
        emission.rateOverTime = flow;
    }

    private void OnParticleCollision(GameObject other)
    {
        riverMiddle.Flowed(40);
    }


}
