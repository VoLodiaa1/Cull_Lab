﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGravity : MonoBehaviour {

    Rigidbody rb;
    public GameObject masalle;
	// Use this for initialization
	void Start () {
        masalle = GameObject.Find("Salle");
<<<<<<< HEAD
    }
=======

        rb = GetComponent<Rigidbody>();
	}
>>>>>>> Dev
	
	// Update is called once per frame
	void Update () {

        RaycastHit Hit;
        if (transform.name != "Base")
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
