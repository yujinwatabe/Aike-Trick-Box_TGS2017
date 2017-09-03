using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poketWatch : MonoBehaviour {
    private Vector3 localGravity = new Vector3(0,-30f,0);
    private float rotate;
    private Rigidbody rb;
    private bool isTime = false;
    private float limit;
    [SerializeField]
    private float limitTime;
    private gyro2 Gyro;

    void Start () {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        isTime = true;
        limit = limitTime;
        Gyro = GameObject.Find("Main Camera").GetComponent<gyro2>();
        rotate = Gyro.GetNowGyro;
    }

    void Update () {
        Debug.Log("rotate=" + rotate);
        //Debug.Log("rotate=" + rotate);
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    if (rotate != -270 && rotate != 270)
        //    {
        //        rotate -= 90;
        //    }
        //    else
        //    {
        //        rotate = 0;
        //    }
        //    Debug.Log("rotate=" + rotate);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    if (rotate != -270 && rotate != 270)
        //    {
        //        rotate += 90;
        //    }
        //    else
        //    {
        //        rotate = 0;
        //    }
        //    Debug.Log("rotate=" + rotate);
        //}

        setLocalGravity();
        if (isTime)
        {
            limitTime -= Time.deltaTime;
            //Debug.Log("TIMELIMIT=" + limitTime);
        }
        if (limitTime <= 0)
        {
            limitTime = limit;
            isTime = false;
        }

    }

    void setLocalGravity(){
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotate = Gyro.GetNowGyro;
            if (Gyro.GetNowGyro != 360)
                rotate += 90;
            
            
            if (rotate == 0 || rotate == 360)
            {
                localGravity = new Vector3(0, 30f, 0);
            }
            else if (rotate == 90 || rotate == -270)
            {
                localGravity = new Vector3(30f, 0, 0);
            }else if(rotate == -180 || rotate == 180)
            {
                localGravity = new Vector3(0, -30f, 0);
            }
            else if (rotate == 270 || rotate == -90)
            {
                localGravity = new Vector3(-30f, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rotate = Gyro.GetNowGyro;
            if (Gyro.GetNowGyro != 0)
            {
                rotate -= 90;
            }else{
                rotate = 270;
            }


            if (rotate == 0 || rotate == 360)
            {
                localGravity = new Vector3(0, 30f, 0);
            }
            else if (rotate == 90 || rotate == -270)
            {
                localGravity = new Vector3(30f, 0, 0);
            }
            else if (rotate == -180 || rotate == 180)
            {
                localGravity = new Vector3(0, -30f, 0);
            }
            else if (rotate == 270 || rotate == -90)
            {
                localGravity = new Vector3(-30f, 0, 0);
            }
        }
        //Debug.Log("rotate=" + rotate);
        rb.AddForce (localGravity, ForceMode.Acceleration);
    }
}
