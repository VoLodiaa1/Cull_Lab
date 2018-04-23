using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalOrientation : MonoBehaviour {

	[Range(0,3)]
	public static int OrientationSalle;
	public int CurrentOrientation;
	// Use this for initialization
	void Start () {
		OrientationSalle =0;
	}

	public void TurnRight()
	{
		OrientationSalle -=1;
		

	}

	public void TurnLeft()
	{
		OrientationSalle +=1;
	}
	
	// Update is called once per frame
	void Update () {
		if(OrientationSalle>3)
		{
			OrientationSalle =0;
		}
		else if(OrientationSalle<0){
			OrientationSalle =3;

		}
		CurrentOrientation =OrientationSalle;
		
	}
}
