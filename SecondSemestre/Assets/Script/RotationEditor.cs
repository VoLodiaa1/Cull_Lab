using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEditor : MonoBehaviour {

	public Camera MyCamera;
	GameObject ObjectSelectionner;
	public int VitesseRotationObject = 10;

	public static bool ModeRotation;
	RaycastHit hit;

	float RotationToMakeObjectX;
	float RotationToMakeObjectY;
	float RotationToMakeObjectZ;

	public enum WhatFace
	{
		None,
		Up,
		Down,
		East,
		West,
		North,
		South
	}

	// Use this for initialization
	void Start () {
        MyCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
        if (LvlEditorBehavior.EditModeActivated == true)
        {
            if (RotationToMakeObjectX != 0 || RotationToMakeObjectY != 0 || RotationToMakeObjectZ != 0)
            {
                RotationObject();
                ModeRotation = true;
                ObjectSelectionner.GetComponent<SphereCollider>().enabled = true;
                ObjectSelectionner.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                ModeRotation = false;
                if (ObjectSelectionner != null)
                {
                    ObjectSelectionner.GetComponent<SphereCollider>().enabled = false;
                    ObjectSelectionner.GetComponent<BoxCollider>().enabled = true;
                }
                Ray ray = MyCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 IncomingVec = hit.normal - Vector3.up;



                    if (Input.GetKeyDown(KeyCode.Mouse1) && hit.transform.tag == "ObjetBougeable")
                    {
                        ObjectSelectionner = hit.transform.gameObject;
                        if (IncomingVec == new Vector3(0, -1, -1))
                            RotationToMakeObjectZ += 90;

                        if (IncomingVec == new Vector3(0, -1, 1))
                            print("north");

                        if (IncomingVec == new Vector3(0, 0, 0))
                            RotationToMakeObjectY += 90;

                        if (IncomingVec == new Vector3(1, 1, 1))
                            print("down");

                        if (IncomingVec == new Vector3(-1, -1, 0))
                            RotationToMakeObjectX += 90;

                        if (IncomingVec == new Vector3(1, -1, 0))
                            print("east");


                    }
                }
            }
        }

    }
	void RotationObject () {

		// ROTATION Y
		if (RotationToMakeObjectY > 0) {
			float depassementY;
			depassementY = RotationToMakeObjectY;
			ObjectSelectionner.transform.Rotate (0, -VitesseRotationObject, 0, Space.World);
			RotationToMakeObjectY -= VitesseRotationObject;
			if (depassementY < 0) {
				RotationToMakeObjectY += depassementY;
			}
		}

		if (RotationToMakeObjectY < 0) {
			float depassementY;
			depassementY = RotationToMakeObjectY;
			ObjectSelectionner.transform.Rotate (0, VitesseRotationObject, 0, Space.World);
			RotationToMakeObjectY += VitesseRotationObject;
			if (depassementY > 0) {
				RotationToMakeObjectY -= depassementY;
			}
		}


		// ROTATION X
		if (RotationToMakeObjectX > 0) {
			float depassementX;
			depassementX = RotationToMakeObjectX;
			ObjectSelectionner.transform.Rotate (-VitesseRotationObject, 0, 0, Space.World);
			RotationToMakeObjectX -= VitesseRotationObject;
			if (depassementX < 0) {
				RotationToMakeObjectX += depassementX;
			}
		}

		if (RotationToMakeObjectX < 0) {
			float depassementX;
			depassementX = RotationToMakeObjectX;
			ObjectSelectionner.transform.Rotate (VitesseRotationObject, 0, 0, Space.World);
			RotationToMakeObjectX += VitesseRotationObject;
			if (depassementX > 0) {
				RotationToMakeObjectX -= depassementX;
			}
		}


		//ROTATION Z
		if (RotationToMakeObjectZ > 0) {
			float depassementZ;
			depassementZ = RotationToMakeObjectZ;
			ObjectSelectionner.transform.Rotate (0, 0, -VitesseRotationObject, Space.World);
			RotationToMakeObjectZ -= VitesseRotationObject;
			if (depassementZ < 0) {
				RotationToMakeObjectZ += depassementZ;
			}
		}

		if (RotationToMakeObjectZ < 0) {
			float depassementZ;
			depassementZ = RotationToMakeObjectZ;
			ObjectSelectionner.transform.Rotate (0, 0, VitesseRotationObject, Space.World);
			RotationToMakeObjectZ += VitesseRotationObject;
			if (depassementZ > 0) {
				RotationToMakeObjectZ -= depassementZ;
			}
		}
	}
}
