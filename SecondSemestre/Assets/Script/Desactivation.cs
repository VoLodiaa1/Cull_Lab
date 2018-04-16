using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivation : MonoBehaviour {

	public GameObject MaSalle;
	Vector3 PositionObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner != null) {
			if (this.gameObject != MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner) {
				gameObject.layer = 2;
			}

			if (PositionObject != MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner.transform.position ) {
				MaSalle.GetComponent<PositionnementObjet> ().impossiblePosition = false;
				PositionObject = MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner.transform.position;
			}
		} else {
			gameObject.layer = 0;
		}

		if (MaSalle.GetComponent<PositionnementObjet> ().ModeRotation == false && this.gameObject != MaSalle.GetComponent<PositionnementObjet>().ObjectSelectionner) {
			GetComponent<Rigidbody> ().useGravity = true;
		} else {
			GetComponent<Rigidbody> ().useGravity = false;
		}
	
	}
		

	void OnTriggerStay(Collider other) {
		print ("Base");
		if (MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner != null) {
			if (this.gameObject != MaSalle.GetComponent<PositionnementObjet> ().ObjectSelectionner) {
				if (other.transform.tag == "ObjetBougeable" && other.transform.name != "seringe") {
					print ("Enfoncer");
					MaSalle.GetComponent<PositionnementObjet> ().impossiblePosition = true;
				}
			}
		}
	}
}
