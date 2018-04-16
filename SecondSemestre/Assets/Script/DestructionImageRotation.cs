using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionImageRotation : MonoBehaviour {

	public Camera MyCamera;
	bool Oneframe;
	public GameObject[] children;
	public Material mymaterial;

	// Use this for initialization
	void Start () {
		MyCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{

		RaycastHit hit;
		Ray ray	= MyCamera.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				if (hit.transform.name == "Yaw" || hit.transform.name == "Roll" || hit.transform.name == "Pitch") {
					Destroy (this.gameObject);
				}
			}
		}

		if (Oneframe == false && Input.GetKeyDown (KeyCode.Mouse1)){
			Destroy (this.gameObject);
		}
		
	}
}


