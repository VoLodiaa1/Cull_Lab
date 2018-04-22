using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour {

	public GameObject MaSalle;

	public bool objectSelected = false;
	public Rigidbody rb;
	int NumeroSeringe;
	float timer;
	bool Afusionner = false;
	bool oneframe;
	float timerColor;
	float Scol;
	float Hcol;
	public int compteur10 =0;

	Color Macolor;
	public float h,s,v;
	public float Hpourcent, Spourcent, Vpourcent;
	public bool premierepenetration = true;


	// Use this for initialization
	void Start () {
       MaSalle = GameObject.Find("Salle");
        Macolor = GetComponent<Renderer> ().material.color;
		Color.RGBToHSV (Macolor,out h,out s,out v);
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (oneframe == true) {

			timer += Time.deltaTime;
			if (timer > 0.25f) {
				oneframe = false;
				timer = 0;
			}
		}


		objectSelected = MaSalle.GetComponent<PositionnementObjet> ().ObjectController;

		if (h < 0) {
			h *= -1;
		}
		if (Afusionner == true) {
			Macolor = Color.HSVToRGB (h, s, v);
			GetComponent<Renderer> ().material.color = Macolor;
		}
	}


	void OnTriggerStay (Collider col) {
		if (col.gameObject.name == "seringe" && objectSelected == false) {
			GameObject parent = col.gameObject.transform.parent.gameObject;
			NumeroSeringe = parent.GetComponent<Seringe> ().numeroSeringe;
			if (compteur10 == 0) {
				timer += Time.deltaTime * 20;
			}
			if (timer > NumeroSeringe) {
				print ("timer");
				if (premierepenetration == true) {
					if (s < 1) {
						Scol = parent.GetComponent<Seringe> ().s * 0.1f;
					} else {
						Scol = 0;
					}
					if (h != 0) {
						Hcol = -parent.GetComponent<Seringe> ().h * 0.1f;
					} else {
						Hcol = parent.GetComponent<Seringe> ().h * 0.1f;
					}
					premierepenetration = false;
				}

				timerColor += Time.deltaTime;
				if (timerColor > 0.1f && compteur10 <10) {
					print ("timercolor");
					s += Scol;
					h += Hcol;
					Afusionner = true;
					compteur10 += 1;
					timerColor = 0;
				}
				if (compteur10 == 10) {
					print ("tombe");
					parent.GetComponent<BoxCollider> ().enabled = false;
					col.GetComponent<BoxCollider> ().enabled = false;
					premierepenetration = true;
					compteur10 = 0;
				}
			}
		}
	}

	void OnCollisionStay (Collision other) {
		if (other.gameObject.name == "Sponge" && objectSelected == false) {
			print ("first step");
		}
	}









//	void OnCollisionStay (Collision col) {
//		if (col.gameObject.name == "Sponge" && objectSelected == false) {
//			print ("1er step");
//			/*if (premierepenetration == true) {
//				if (s < 1) {
//					Scol = col.gameObject.GetComponent<Sponge> ().v*0.1f;
//				} else {
//					Scol = 0;
//				}
//				if (h != 0) {
//					Hcol = -col.gameObject.GetComponent<Sponge> ().h*0.1f;
//				} else {
//					Hcol = col.gameObject.GetComponent<Sponge> ().h*0.1f;
//				}
//				premierepenetration = false;
//				print ("bugger");
//			}*/
//			Rigidbody rbcol	= col.gameObject.GetComponent<Rigidbody> ();
//
//			if (gameObject.transform.position.y > col.gameObject.transform.position.y && rb.velocity.magnitude == 0 && rbcol.velocity.magnitude == 0) {
//				print ("azerftaze");
//				if (gameObject.transform.position.x == col.gameObject.transform.position.x && gameObject.transform.position.z == col.gameObject.transform.position.z) {
//					print ("pasbouger");
//					if (h == 0 || Hcol == 0) {
//						h -= Hpourcent;
//						col.gameObject.GetComponent<Sponge> ().h = 0;
//						s -= Spourcent;
//						col.gameObject.GetComponent<Sponge> ().s = 0;
//						Afusionner = true;
//						if (h == 0 && Hcol == 0) {
//
//						} else {
//							Destroy (this.gameObject);
//						}
//					} else {
//						print ("colorisation");
//						timerColor += Time.deltaTime;
//						if (timerColor > 0.1f && compteur10 < 10) {
//							print ("timercolor2");
//							s += Scol;
//							h += Hcol;
//							Afusionner = true;
//							compteur10 += 1;
//							timerColor = 0;
//						}
//						if (compteur10 == 10) {
//							print ("tombe");
//							this.GetComponent<BoxCollider> ().enabled = false;
//							premierepenetration = true;
//							compteur10 = 0;
//						}
//					}
//
//				}
//			}
//		}
//	}

}
