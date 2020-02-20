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

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }


    void Update()
    {
        if (hitRain)
        {
            if (rainChanger.Rainfall() < 29)
            {
                 delta += Time.deltaTime;
            }else if(rainChanger.Rainfall() < 59)
            {
                 
            }

        }

        if(delta > hitRainTimer)
        {
            
        }
        
    }

    void Growth()
    {
        //IvyGenerate();
    }

    void IvyGenerate()
    {
        GameObject ivy = Instantiate(ivyPrefab, new Vector3(position.x, position.y - 0.5f, position.z), Quaternion.identity);

        ivy.transform.localRotation = transform.localRotation;

        ivy.transform.parent = transform;

    }


}
