using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 段差をのぼる処理は仮
// アニメーションができたら変更

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    float accel = 10f;       // 加速度

    [SerializeField]
    float maxSpeed = 3f;   // 最高速

    [SerializeField]
    float climbTime = 0.4f;

    [SerializeField]
    CameraController cameraController;

    Vector3 endposition;
    Vector3 startPosition;
    Rigidbody rigidbody;

    float startTime = 0;
    float speedX = 0;            // 現在の速度
    float speedZ = 0;
    float steering = 0f;        // 現在の回転角

    bool step = false;

    float vertical;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Y axis");

        horizontal = Input.GetAxis("X axis");

        Rotation();

        float hypotenuse = Mathf.Sqrt(vertical * vertical + horizontal * horizontal); //　斜辺を取得
        float speed = hypotenuse * maxSpeed * Time.deltaTime;                  //　移動を1つの変数にまとめる
        transform.Translate(0,0,speed);        //　移動
        Debug.Log(this.gameObject.transform.forward);

        if (step)
        {
            Climb();

        }

    }

    /// <summary>
    /// 回転処理
    /// </summary>
    void Rotation()
    {
        //float vertical0 = Input.GetAxis("5th axis");
        //float horizontal1 = Input.GetAxis("4th axis");
        //AdjustmentAngle();  //　角度調整



        //　入力が行われている時
        if (vertical != 0 || horizontal != 0)
        {
            this.transform.eulerAngles = new Vector3(0, cameraController.GetYRotation(), 0);
            //Quaternion.LookRotation(new Vector3(0,CameraController.GetYRotation(),0));
            Vector3 inputAngle = new Vector3(horizontal, 0, vertical);
            float theta = Mathf.Acos(Vector3.Dot(inputAngle, Vector3.forward) / (inputAngle.magnitude * Vector3.forward.magnitude)) * Mathf.Rad2Deg;
            if(horizontal < 0) { theta *= -1; }
            transform.Rotate(0,theta,0);
        }
    }


    void Climb()
    {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > this.climbTime)
        {
            transform.position = endposition;
            rigidbody.velocity = Vector3.zero;
            step = false;

        }

        var rate = diff / climbTime;

        transform.position = Vector3.Lerp(startPosition, endposition, rate);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Step")
        {
            if(!(collision.gameObject.tag == "Ground"))
            {
                startPosition = transform.position;
                endposition = new Vector3(startPosition.x, startPosition.y + 0.7f, startPosition.z);

                startTime = Time.timeSinceLevelLoad;
                step = true;
            }           
        }
    }


    /// <summary>
    /// 現在の速度を取得
    /// </summary>
    /// <returns></returns>
    public float Speed()
    {
        return this.speedZ;
    }

    
}
