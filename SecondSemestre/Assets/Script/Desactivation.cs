﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivation : MonoBehaviour {

	public GameObject MaSalle;
	Vector3 PositionObject;
	[HideInInspector] public int valeurmvt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner != null) {
			if (this.gameObject != MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner) {
			}

			if (PositionObject != MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner.transform.position ) {
				print ("positionposible");
				MaSalle.GetComponent<PositionnementObjet> ().impossiblePosition = false;
				valeurmvt += 1;

				PositionObject = MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner.transform.position;
			}
		} else {
			
		}

		if (MaSalle.GetComponent<PositionnementObjet> ().ModeRotation == false && this.gameObject != MaSalle.GetComponent<PositionnementObjet>().ObjectSelectionner) {
			GetComponent<Rigidbody> ().useGravity = true;
		} else {
			GetComponent<Rigidbody> ().useGravity = false;
		}
	
	}
		

	void OnTriggerStay(Collider other) {
		if (MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner != null) {
			if (this.gameObject == MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner) {
				if (other.transform.tag == "ObjetBougeable" && other.transform.name != "seringe" && this.transform.name != "base") {
					print ("Enfoncer");
					MaSalle.GetComponent<PositionnementObjet> ().impossiblePosition = true;
				}
			}
		}
	}
}
