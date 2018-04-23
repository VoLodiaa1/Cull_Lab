using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour {

	public GameObject Masalle;
	Quaternion RotationOriginel;
    public GameObject PivotCamera;

	// Use this for initialization
	void Start () {
		RotationOriginel = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        


		RaycastHit Hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.back), out Hit, Mathf.Infinity)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back*10), Color.green);
            if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
            {
                if (Hit.transform.name == "Avatar")
                {
                    print("Vol");
                    Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                    rb.AddForce (this.transform.forward * -10);
                }
            }else
            {

            }
		}
	}
}
