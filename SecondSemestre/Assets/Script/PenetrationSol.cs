using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrationSol : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -0.5f) {
			Destroy (this.gameObject);
		}
	}



}
