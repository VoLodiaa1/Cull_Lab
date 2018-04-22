using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour {

<<<<<<< HEAD

	
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


            RaycastHit Hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, Mathf.Infinity))
            {
                if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
                {
                    if (Hit.transform.name == "Avatar")
                    {
                        Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                        rb.AddForce(this.transform.forward * 10);
                    }
                }
            }
        }
    }
=======
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
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Hit, Mathf.Infinity)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward*10), Color.green);
            if (Masalle.GetComponent<PositionnementObjet>().ObjectController == false && Masalle.GetComponent<RotationSalle>().RotationToMakeY == 0)
            {
                if (Hit.transform.name == "Avatar")
                {
                    print("Vol");
                    Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                    rb.AddForce (this.transform.forward * 10);
                }
            }else
            {

            }
		}
	}
>>>>>>> def56032fe7ee8756226eeaf12bae98245dc6fd0
}

