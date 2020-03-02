using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField]
    CameraController cameraController;

    [SerializeField]
    float maxSpeed;

    float vertical;
    float horizontal;

    Vector2 MoveDistance = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 雲が毎フレーム行う処理
    // TODO:適切な名前に変更
    public void CloudUpdate()
    {
        horizontal = Input.GetAxis("MoveHorizontal");

        vertical = Input.GetAxis("MoveVertical");

        Move();
    }

    void Move()
    {
        //　入力が行われている時
        if (vertical != 0 || horizontal != 0)
        {
            this.transform.eulerAngles = new Vector3(0, cameraController.GetYRotation(), 0);
            Vector3 inputAngle = new Vector3(horizontal, 0, vertical);
            float theta = Mathf.Acos(Vector3.Dot(inputAngle, Vector3.forward) / (inputAngle.magnitude * Vector3.forward.magnitude)) * Mathf.Rad2Deg;
            if (horizontal < 0) { theta *= -1; }
            transform.Rotate(0, theta, 0);

            float hypotenuse = Mathf.Sqrt(vertical * vertical + horizontal * horizontal); //　斜辺を取得
            float speed = hypotenuse * maxSpeed * Time.deltaTime;                  //　移動を1つの変数にまとめる
            transform.Translate(0, 0, speed);        //　移動

            transform.eulerAngles = Vector3.zero;

        }
    }

    void Rotate()
    {

    }

}
