using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField]
    float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        

    }

    void Move()
    {
        float vertical = Input.GetAxis("Y axis");
        float horizontal = Input.GetAxis("X axis");

        float hypotenuse = Mathf.Sqrt(vertical * vertical + horizontal * horizontal); //　斜辺を取得
        float speed = hypotenuse * maxSpeed * Time.deltaTime;                  //　移動を1つの変数にまとめる
        transform.Translate(0, 0, speed);        //　移動
    }

    void Rotate()
    {

    }
}
