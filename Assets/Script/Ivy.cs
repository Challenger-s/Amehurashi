using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivy : MonoBehaviour
{
    [SerializeField]
    RainChanger rainChanger;

    bool hitRain = false;
    float delta = 0;
    float hitRainTimer = 1f;

    Vector3 scale;


    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }


    void Update()
    {
        
        if (hitRain)
        {
            delta += Time.deltaTime;

            if(rainChanger.Rainfall() < 9)
            {
                delta = 0;
            }           
            else if (rainChanger.Rainfall() < 29)
            {
                hitRainTimer = 3f;
            }
            else if (rainChanger.Rainfall() < 59)
            {
                hitRainTimer = 2f;
            }

        }

        if (delta > hitRainTimer)
        {

            Grow();
        }

    }

    void Grow()
    {

        if (scale.y < 6)
        {
            transform.localScale = new Vector3(scale.x, scale.y + (3f * Time.deltaTime), scale.z);

            scale = transform.localScale;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cloud")
        {
            hitRain = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cloud")
        {
            hitRain = false;
        }
    }
}
    



