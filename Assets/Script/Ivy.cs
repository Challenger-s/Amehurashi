using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivy : MonoBehaviour
{
    [SerializeField]
    RainChanger rainChanger;

    [SerializeField]
    GameObject ivyPrefab;

    bool hitRain = false;
    float delta = 0;
    float hitRainTimer;

    Vector3 startPosition;
    Vector3 endPosition;
    Vector3 pastPosition;

    float startTime = 0;
    float growTime = 1f;



    // Start is called before the first frame update
    void Start()
    {

        pastPosition = startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y + 2.5f, startPosition.z);

        startTime = Time.timeSinceLevelLoad;

        IvyGenerate();
    }


    void Update()
    {
        
        if (hitRain)
        {
            if (rainChanger.Rainfall() < 29)
            {
                delta += Time.deltaTime;
                hitRainTimer = 3f;
            }else if(rainChanger.Rainfall() < 59)
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
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > growTime)
        {
            transform.position = endPosition;
        }

        var rate = diff / growTime;

        transform.position = Vector3.Lerp(startPosition, endPosition, rate);

        if(transform.position.y - pastPosition.y > 0.5f)
        {
            pastPosition = transform.position;
            IvyGenerate();
        }

        
    }

    void IvyGenerate()
    {
        GameObject ivy = Instantiate(ivyPrefab, new Vector3(startPosition.x, startPosition.y - 0.5f, startPosition.z), Quaternion.identity);

        ivy.transform.localRotation = transform.localRotation;

        ivy.transform.parent = transform;

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
    



