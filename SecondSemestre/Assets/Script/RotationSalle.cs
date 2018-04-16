using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotationSalle : MonoBehaviour {

	//Public
	public int VitesseRotationSalle = 10;


	//Private
	float RotationToMakeY = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {
			RotationToMakeY -= 90;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			RotationToMakeY += 90;
		}
		if (RotationToMakeY != 0) {
			RotationHoraire();
		}
		
	}


	public void RotationHoraire (){
		if (RotationToMakeY > 0) {
			float depassementY ;
			depassementY = RotationToMakeY;
			transform.Rotate (0, -VitesseRotationSalle, 0,Space.World);
			RotationToMakeY -= VitesseRotationSalle;
			if (depassementY < 0) {
				RotationToMakeY += depassementY;
			}
		}

		if (RotationToMakeY < 0) {
			float depassementY ;
			depassementY = RotationToMakeY;
			transform.Rotate (0, VitesseRotationSalle, 0,Space.World);
			RotationToMakeY += VitesseRotationSalle;
			if (depassementY > 0) {
				RotationToMakeY -= depassementY;
			}
		}
	}

	public void MakeTurn () {

		if (RotationToMakeY == 0) {
			if (EventSystem.current.currentSelectedGameObject.name == "Negatif") {
				RotationToMakeY -= 90;
			}
			if (EventSystem.current.currentSelectedGameObject.name == "Positif") {
				RotationToMakeY += 90;
			}
		}
	}

}
