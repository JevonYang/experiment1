using System;
using UnityEngine;
using System.Collections;


public class Circle : MonoBehaviour
{

    //public static float[] shoulder = new float[3] {0f,0f,0f };


    /**/

    float xSpeed = 0.001f;
    float ySpeed = 0.001f;
    float zSpeed = 0.001f;
     //float xAxis=0, yAxis=0, zAxis=0;

    void Awake()
    {
        //Debug.Log ("圆环的位置：" + "x:" + transform.position.x + "  y:" +transform.position.y + "  z:" + transform.position.z);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        /*获取VICON坐标*/
/*
        Vector3 vectorPosition = new Vector3();

        vectorPosition.x = -(Main.position[0]-Main.shoulder[0])/1000; 
        vectorPosition.y = (Main.position[2]-Main.shoulder[1])/1000; 
        vectorPosition.z = -(Main.position[1]-Main.shoulder[2])/1000; 

        gameObject.transform.position =vectorPosition;//坐标赋值

        //float[] check = new float[3];
        //check = Main.origin;

        for (int index = 0; index < 3; index++)
        {
            Main.prePosition[index] = Main.position[index];
        }
        if (Main.prePosition[0] != 0||Main.prePosition[1]!=0||Main.prePosition[2]!=0)
        {
            gameObject.transform.Translate(0, 0, vectorPosition.z);
            gameObject.transform.Translate(0, vectorPosition.y, 0);
            gameObject.transform.Translate(vectorPosition.x, 0, 0);

        }
        Console.WriteLine("{0},{1},{2}",vectorPosition.x,vectorPosition.y,vectorPosition.z);
       */        

       
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, 0, zSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0, 0, -zSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-xSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(xSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.Translate(0, -ySpeed, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.Translate(0, ySpeed, 0);

        } /**/
    }

    void OnTriggerStay(Collider e)
    {


    }

    void OnTriggerExit(Collider e)
    {

    }
}