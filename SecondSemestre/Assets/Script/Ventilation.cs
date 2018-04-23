using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour {


	
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
                    if (Hit.transform.name.Contains( "Avatar"))
                    {
                        Rigidbody rb = Hit.transform.GetComponent<Rigidbody>();
                        rb.AddForce(this.transform.forward * 10);
                    }
                }
            }
        }
    }
}

