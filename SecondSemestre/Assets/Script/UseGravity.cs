using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGravity : MonoBehaviour {

    Rigidbody rb;
    public GameObject masalle;
    [HideInInspector] public bool injecteurDone = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        masalle = GameObject.Find("Salle");
<<<<<<< HEAD
    }
	
	// Update is called once per frame
	void Update () {
=======

    }

    // Update is called once per frame
    void Update () {
>>>>>>> def56032fe7ee8756226eeaf12bae98245dc6fd0

        RaycastHit Hit;

        if (injecteurDone == false)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out Hit, 0.501f))
            {
                rb.useGravity = false;
            }
            else
            {
                if (masalle.GetComponent<PositionnementObjet>().ObjectSelectionner == this.gameObject)
                {
                    rb.useGravity = false;
                }
                else
                {
                    rb.useGravity = true;
                }

            }
        }
        else
        {
            rb.useGravity = true;
        }
	}
}
