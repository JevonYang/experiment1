using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		GUI.Label (new Rect (310, 200, 150, 100), "Participant's Name");
		Gdata.text = GUI.TextField(new Rect (310, 250, 100, 20),Gdata.text);

        GUI.Label(new Rect(660, 340, 150, 100), "VICON Process Path");
        Camera_Position.path= GUI.TextField(new Rect(610, 370, 250, 20), Camera_Position.path);


        GUI.Label(new Rect(660, 200, 150, 100), "Participant's Parameter");

        GUI.Label(new Rect(610, 230, 150, 100), "Eye Position");
        Camera_Position.x = GUI.TextField(new Rect(610, 250, 100, 20), Camera_Position.x);
        Camera_Position.y = GUI.TextField(new Rect(610, 280, 100, 20), Camera_Position.y);
        Camera_Position.z = GUI.TextField(new Rect(610, 310, 100, 20), Camera_Position.z);

        GUI.Label(new Rect(760, 230, 150, 100), "Shoulder Position");
        Camera_Position.shoulder_x = GUI.TextField(new Rect(760, 250, 100, 20), Camera_Position.shoulder_x);
        Camera_Position.shoulder_y = GUI.TextField(new Rect(760, 280, 100, 20), Camera_Position.shoulder_y);
        Camera_Position.shoulder_z = GUI.TextField(new Rect(760, 310, 100, 20), Camera_Position.shoulder_z);

        
       // print(Camera_Position.x);
        if (GUI.Button (new Rect (310, 310, 100, 20), "START!"))
		    {  
			    Application.LoadLevel(1);
				
		    } 
       
	}
}
