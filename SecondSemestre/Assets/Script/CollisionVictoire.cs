using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVictoire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		if (col.transform.name == "Avatar") {
			print ("VICTOIRE");
		}
	}
}
