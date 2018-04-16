using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour {

	public GameObject MaSalle;

	bool objectSelected = false;
	bool ObjectRotationned = false;
	public Rigidbody rb;
	int NumeroSeringe;
	float timer;
	bool Afusionner = false;

	Color Macolor;
	public float h,s,v;

	// Use this for initialization
	void Start () {
		Macolor = GetComponent<Renderer> ().material.color;
		Color.RGBToHSV (Macolor,out h,out s,out v);
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		objectSelected = MaSalle.GetComponent<PositionnementObjet> ().ObjectController;
		ObjectRotationned = MaSalle.GetComponent<PositionnementObjet> ().ModeRotation;

		if (h < 0) {
			h *= -1;
		}
		if (Afusionner == true) {
			Macolor = Color.HSVToRGB (h, s, v);
			GetComponent<Renderer> ().material.color = Macolor;
		}
	}


	void OnTriggerStay (Collider col) {
		if (col.gameObject.name == "seringe" && objectSelected == false && ObjectRotationned == false) {
			GameObject parent = col.gameObject.transform.parent.gameObject;
			NumeroSeringe = parent.GetComponent<Seringe> ().numeroSeringe;
			timer += Time.deltaTime * 20;
			if (timer > NumeroSeringe) {
				s = 1;

				print ("seringe");
				float Hcol = col.GetComponentInParent<Seringe> ().h;
				h = h - Hcol;
				timer = 0;
				Afusionner = true;
				Destroy (parent.gameObject);
			}
		}
	}

	void OnCollisionStay (Collision col) {
		if (col.gameObject.name == "Sponge" && objectSelected == false && ObjectRotationned == false) {
			float Hcol = col.gameObject.GetComponent<Sponge> ().h;
			float Vcol = col.gameObject.GetComponent<Sponge> ().v;
			Rigidbody rbcol	= col.gameObject.GetComponent<Rigidbody> ();

			if (gameObject.transform.position.y > col.gameObject.transform.position.y && rb.velocity.magnitude == 0 && rbcol.velocity.magnitude == 0) {
				if (gameObject.transform.position.x == col.gameObject.transform.position.x && gameObject.transform.position.z == col.gameObject.transform.position.z) {
					if (h == 0 || Hcol == 0) {
						h = 0;
						col.gameObject.GetComponent<Sponge> ().h = 0;
						s = 0;
						col.gameObject.GetComponent<Sponge> ().s = 0;
						Afusionner = true;
						Destroy (this.gameObject);
					} else {
						h = h - Hcol;
						col.gameObject.GetComponent<Sponge> ().h = h;
						Afusionner = true;
						Destroy (this.gameObject);
					}

				}
			}
		}
	}
}
