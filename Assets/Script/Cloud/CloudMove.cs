using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    float Xspeed;
    float Zspeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        transform.Translate(this.Xspeed * Time.deltaTime , 0, this.Zspeed * Time.deltaTime);

        

        // 減速処理
        if (this.Xspeed > 0)
        {
            this.Xspeed -= 20 * 0.5f * Time.deltaTime;
            if (this.Xspeed < 0)
            {
                this.Xspeed = 0;
            }
        }
        else if (this.Xspeed < 0)
        {
            this.Xspeed += 20 * 0.5f * Time.deltaTime;
            if (this.Xspeed > 0)
            {
                this.Xspeed = 0;
            }
        }

        if (this.Zspeed > 0)
        {
            this.Zspeed -= 20 * 0.5f * Time.deltaTime;
            if (this.Zspeed < 0)
            {
                this.Zspeed = 0;
            }
        }
        else if (this.Zspeed < 0)
        {
            this.Zspeed += 20 * 0.5f * Time.deltaTime;
            if (this.Zspeed > 0)
            {
                this.Zspeed = 0;
            }
        }

    }

    void Mover()
    {


        float vertical = Input.GetAxis("Y axis");

        float horizontal = Input.GetAxis("X axis");

        // valueの値の範囲が-1から1を超えないように、下限上限を設定
        horizontal  = Mathf.Clamp(horizontal, -1,  1);

        vertical    = Mathf.Clamp(vertical  , -1,  1);

        this.Xspeed += horizontal * 20 * Time.deltaTime;

        this.Zspeed += vertical * 20 * Time.deltaTime;

        

        // 上限下限を設定 Mathf.Clamp(対象の値, 最小値, 最大値)
        this.Xspeed = Mathf.Clamp(this.Xspeed, -3, 3);

        this.Zspeed = Mathf.Clamp(this.Zspeed, -3, 3);
   
    }

}
