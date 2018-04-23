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
        Masalle = GameObject.Find("Salle");
        PivotCamera = GameObject.Find("PivotCamera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        


		RaycastHit Hit;
        if (GlobalOrientation.OrientationSalle == 0)
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out Hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back * 10), Color.green);
                if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
                {
                    if (Hit.transform.name.Contains("Avatar"))
                    {
                        print("Vol");
                        Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                        rb.AddForce(this.transform.forward * -10);
                    }
                }
                else
                {

                }

            }
        }

        if (GlobalOrientation.OrientationSalle == 1)
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out Hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left * 10), Color.green);
                if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
                {
                    if (Hit.transform.name.Contains("Avatar"))
                    {
                        print("Vol");
                        Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                        rb.AddForce(this.transform.right * -10);
                    }
                }
                else
                {

                }

            }
        }


        if (GlobalOrientation.OrientationSalle == 2)
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 10), Color.green);
                if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
                {
                    if (Hit.transform.name.Contains("Avatar"))
                    {
                        print("Vol");
                        Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                        rb.AddForce(this.transform.forward * 10);
                    }
                }
                else
                {

                }

            }
        }

        if (GlobalOrientation.OrientationSalle == 3)
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out Hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right * 10), Color.green);
                if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
                {
                    if (Hit.transform.name.Contains("Avatar"))
                    {
                        print("Vol");
                        Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                        rb.AddForce(this.transform.right * 10);
                    }
                }
                else
                {

                }

            }
        }

        
    }
}
