using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorationCase : MonoBehaviour {

	public GameObject MaSalle;
	GameObject MonObject;
	bool ModeRotation;
	int positionX;
	int positionY;
	int positionZ;
	int TotalePosition;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TotalePosition = positionX + positionY + positionZ;

		if (MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner != null) {
			MonObject = MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner;
			ModeRotation = MaSalle.GetComponent<PositionnementObjet> ().ModeRotation;
			if (ModeRotation == false) {
				if (transform.position.x < MonObject.transform.position.x + 0.01f && transform.position.x > MonObject.transform.position.x - 0.01f) {
					positionX = 1;
				} else {
					positionX = 0;
				}

				if (transform.position.y < MonObject.transform.position.y + 0.01f && transform.position.y > MonObject.transform.position.y - 0.01f) {
					positionY = 1;
				} else {
					positionY = 0;
				}

				if (transform.position.z < MonObject.transform.position.z + 0.01f && transform.position.z > MonObject.transform.position.z - 0.01f) {
					positionZ = 1;
				} else {
					positionZ = 0;
				}

				if (TotalePosition == 2) {
					if (MaSalle.GetComponent<PositionnementObjet> ().impossiblePosition == false) {
						GetComponent<Renderer> ().material.color = Color.green;
					} else {
						GetComponent<Renderer> ().material.color = Color.red;
					}
				} else {
					GetComponent<Renderer> ().material.color = Color.white;
				}
			}
		} else {
			GetComponent<Renderer> ().material.color = Color.white;
		}


		
	}
}
