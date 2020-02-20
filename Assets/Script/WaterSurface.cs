using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSurface : MonoBehaviour
{
    [SerializeField]
    RainChanger rainChange;

    bool riverON = false;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (riverON)
        {
            if (rainChange.Rainfall() > 59)
            {
                transform.Translate(0, 1f * Time.deltaTime, 0);
            }
            else if (rainChange.Rainfall() > 29)
            {
                transform.Translate(0, 0.5f * Time.deltaTime, 0);
            }
            else if (rainChange.Rainfall() > 5)
            {
                transform.Translate(0, 0.2f * Time.deltaTime, 0);
            }

            else if (transform.position.y > pos.y)
            {
                transform.Translate(0, -0.5f * Time.deltaTime, 0);
            }
            else
            {
                transform.position = pos;
            }


        }
        else
        {
            if (transform.position.y > pos.y)
            {
                transform.Translate(0, -0.5f * Time.deltaTime, 0);
            }
            else
            {
                transform.position = pos;
            }
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
