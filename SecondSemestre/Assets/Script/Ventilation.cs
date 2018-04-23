using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour {

<<<<<<< HEAD

=======
	public GameObject Masalle;
	Quaternion RotationOriginel;
    public GameObject PivotCamera;

	// Use this for initialization
	void Start () {
		RotationOriginel = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        Masalle = GameObject.Find("Salle");
        PivotCamera = GameObject.Find("PivotCamera");
	}
>>>>>>> Dev
	
    public GameObject Masalle;
    GameObject Helice;
    Quaternion RotationOriginel;

    // Use this for initialization
    void Start() {
        
            Masalle = GameObject.Find("Salle");
            //Helice = this.gameObject.transform.GetChild (1).gameObject;
            RotationOriginel = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (LvlEditorBehavior.EditModeActivated == false)
        {
            if (transform.rotation != RotationOriginel)
            {
                transform.rotation = RotationOriginel;
            }

            //Helice.transform.Rotate (0, 0, 10);


<<<<<<< HEAD
            RaycastHit Hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, Mathf.Infinity))
=======
		RaycastHit Hit;
<<<<<<< HEAD
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.back), out Hit, Mathf.Infinity)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back*10), Color.green);
            if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
>>>>>>> IntegrationAssetsHugo
            {
                if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
                {
<<<<<<< HEAD
                    if (Hit.transform.name == "Avatar")
                    {
                        Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                        rb.AddForce(this.transform.forward * 10);
                    }
=======
                    print("Vol");
                    Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                    rb.AddForce (this.transform.forward * -10);
>>>>>>> IntegrationAssetsHugo
                }
            }
        }
=======
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

        
>>>>>>> Dev
    }
}

