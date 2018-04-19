using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour {

	public GameObject Masalle;
	GameObject Helice;
	Quaternion RotationOriginel;

	// Use this for initialization
	void Start () {
		Helice = this.gameObject.transform.GetChild (1).gameObject;
		RotationOriginel = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation != RotationOriginel) {
			transform.rotation = RotationOriginel;
		}

		Helice.transform.Rotate (5, 0, 0);


		RaycastHit Hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.right), out Hit, Mathf.Infinity)) {
			
			if (Masalle.GetComponent<PositionnementObjet> ().ObjectSelectionner != this.gameObject && Masalle.GetComponent<RotationSalle>().RotationToMakeY==0) {
				if (Hit.transform.name == "Avatar") {

					Rigidbody rb = Hit.transform.GetComponent<Rigidbody> ();
					rb.AddForce (this.transform.right * 10);
				}
			}
		}
	}
}
