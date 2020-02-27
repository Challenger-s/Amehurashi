using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {

        if (hitRain)
        {
            delta += Time.deltaTime;

            if (rainChanger.Rainfall() < 9)
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
        if (scale.x < 3)
        {
            transform.localScale = new Vector3(scale.x + (1f * Time.deltaTime), scale.y + (1f * Time.deltaTime), scale.z + (1f * Time.deltaTime));

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
