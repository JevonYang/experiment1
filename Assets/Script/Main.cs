using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

public class Main : MonoBehaviour
{

    //public static float timeOver = 10.0f;

    /* Objects in Unity scene*/
    public GameObject line;

    public GameObject cylinder;
    public GameObject circle;//ring object
    public GameObject camera;
    public AudioSource sound;

    /*Data recorder*/
    public static FileStream fs;
    public static StreamWriter sw;//datarecorder
    public static System.DateTime spanTime1, spanTime2;

    /*Counters*/
    int[] myIntArray;           //Counter for steering law
    int frequecyCounter = 1;    //number of experiment times


    /*Flags*/
    public static bool destoryFlag1, destoryFlag2,destoryFlag3 = false;//flag for destorying object-line

    public static bool destoryLine, destoryCicle;                       //Flag for destorying Line and Cicle

    public static int lineFlag,circleFlag,positionFlag,fitFlag;


    void Awake()
    {

    }

    void Start()
    {

        /* Data record function initialization*/

        fs = new FileStream(Application.dataPath + "/" + Gdata.text + ".txt", FileMode.Append);
        sw = new StreamWriter(fs);


        /*Experiment Start*/

        RandomArray();

        AppearLine(myIntArray[frequecyCounter]);

        frequecyCounter++;


    }

    void Update()
    {

        /*  Counter Starts*/
        if (frequecyCounter <= 153)
        {
            if (destoryFlag1 == true && destoryFlag2==true && destoryFlag3==true)
            {
                destoryFlag1 = false;

                AppearLine(myIntArray[frequecyCounter]);
            }
            

        }
        else
        {

            GUI.Box(new Rect(0,0,Screen.width/2,Screen.height/2),"Congrats! Well Done and Thank you for your help!");

        }

    }

    #region no need to read


    /*Line Positon*/
    void AppearLine(int i)
    {
        Vector3 v;

        positionFlag = i % 17;

        lineFlag = (i/17)%3;

        circleFlag = ((i/17)/3)%3;

        float m = (float)(Mathf.Sqrt(2) * 0.05);

        float factor = 1.5f;
        
        switch (positionFlag)
        {
            case 1:
                v = new Vector3(0.1f, 0, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(0,10,MakeALine.length,MakeACycle.radius);
                break;
            case 2:
                v = new Vector3(m, m, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(45, 10, MakeALine.length, MakeACycle.radius);
                break;
            case 3:
                v = new Vector3(0, 0.1f, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(90, 10, MakeALine.length, MakeACycle.radius);
                break;
            case 4:
                v = new Vector3(-m, m, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(135, 10, MakeALine.length, MakeACycle.radius);
                break;
            case 5:
                v = new Vector3(-0.1f, 0, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(180, 10, MakeALine.length, MakeACycle.radius);
                break;
            case 6:
                v = new Vector3(-m, -m, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(225, 10, MakeALine.length, MakeACycle.radius);
                break;
            case 7:
                v = new Vector3(0, -0.1f, 0);
                Instantiate(line, v, transform.rotation);         
                DataLog(270, 10, MakeALine.length, MakeACycle.radius);
                break;
            case 8:
                v = new Vector3(m, -m, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(315, 10, MakeALine.length, MakeACycle.radius);
                break;
            case 9:
                v = new Vector3(0.1f * factor, 0, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(0, 15, MakeALine.length, MakeACycle.radius);
                break;
            case 10:
                v = new Vector3(m * factor, m * factor, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(45, 15, MakeALine.length, MakeACycle.radius);
                break;
            case 11:
                v = new Vector3(0, 0.1f * factor, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(90, 15, MakeALine.length, MakeACycle.radius);
                break;
            case 12:
                v = new Vector3(-m * factor, m * factor, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(135, 15, MakeALine.length, MakeACycle.radius);
                break;
            case 13:
                v = new Vector3(-0.1f * factor, 0, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(180, 15, MakeALine.length, MakeACycle.radius);
                break;
            case 14:
                v = new Vector3(-m * factor, -m * factor, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(225, 15, MakeALine.length, MakeACycle.radius);
                break;
            case 15:
                v = new Vector3(0, -0.1f * factor, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(270, 15, MakeALine.length, MakeACycle.radius);
                break;
            case 16:
                v = new Vector3(m * factor, -m * factor, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(315, 15, MakeALine.length, MakeACycle.radius);
                break;

            case 0:
                v = new Vector3(0, 0, 0);
                Instantiate(line, v, transform.rotation);
                DataLog(0, 0, MakeALine.length, MakeACycle.radius);
                break;

        }
    }

    /* Random Function*/
    void RandomArray()
    {
        myIntArray = new int[155];

        System.Random r = new System.Random();
        for(int i=1; i <= 153; i++)
        {
            myIntArray[i] = i;
        }

        for(int i = 153; i >= 2; i--)
        {
            int j = r.Next(1, i - 1);
            int t = myIntArray[i];
            myIntArray[i]= myIntArray[j];
            myIntArray[j]= t;
            
        }
    }

    void DataLog(float i,float j,float m,float n)
    {
        sw.WriteLine(i);
        sw.WriteLine(j);
        sw.WriteLine(m);
        sw.WriteLine(n);
        sw.Flush();
    }

    #endregion

}