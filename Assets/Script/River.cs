using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    ParticleSystem particleSystem;

    [SerializeField]
    RainChanger rainChanger;

    bool riverON = false;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        var emission = particleSystem.emission;
        emission.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = particleSystem.emission;
        //Debug.Log(riverON);
        if (riverON)
        {
            if(rainChanger.Rainfall() < 5)
            {
                emission.rateOverTime = 0;
            }else if(rainChanger.Rainfall() > 29)
            {
                emission.rateOverTime = 20;
            }else if (rainChanger.Rainfall() > 59)
            {
                emission.rateOverTime = 40;
            }
            
        }
        else
        {
            emission.rateOverTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cloud")
        {
            riverON = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cloud")
        {
            riverON = false;
        }
    }


}
