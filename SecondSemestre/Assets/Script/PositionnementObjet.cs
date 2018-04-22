using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionnementObjet : MonoBehaviour {

	//Public
	public Camera MyCamera;
	//public Material Ghostmaterial;
	public GameObject ObjectSelectionner;
	public GameObject ImageRotation;
	public float VitesseRotationObject = 1;
	public GameObject[] ObjectInScene;


	//Private
	float RotationToMakeObjectX;
	float RotationToMakeObjectY;
	float RotationToMakeObjectZ;
	public float PositionY = 0.5f;
	float timer =0;
	Vector3 PositionObject;
	[HideInInspector] public bool ObjectController = false;
	[HideInInspector] public bool ModeRotation = false;
	[HideInInspector] public bool oneframe;
	public bool RotationDone = false;
	public bool PeutChangerDeMode = true;
	public bool impossiblePosition = false;
	[HideInInspector]public Rigidbody rb;
	int monter =0;
	int surplus;
	[HideInInspector] public bool CorrectionBug = false;
	public Text compteurdemouvement;
	int valeurmvt;
	public Text nbaction;
	int nombreaction;
	//[HideInInspector] public Material Basematerial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (ObjectSelectionner != null) {
			valeurmvt = ObjectSelectionner.GetComponent<Desactivation> ().valeurmvt;
			compteurdemouvement.text = " Nb mouvement : " + valeurmvt.ToString ();
		} else {
			compteurdemouvement.text = " Nb mouvement : " + valeurmvt.ToString ();
		}

		// REPLACEMENT HAUT DE PILE
		if (impossiblePosition == true && Input.GetKeyUp(KeyCode.Mouse0)) {
			ObjectSelectionner.transform.position = PositionObject;
//			for (int i = 0; i < ObjectInScene.Length; i++) {
//				if (ObjectInScene [i] != ObjectSelectionner) {
//					print (i);
//					if (ObjectInScene [i].transform.position.x < ObjectSelectionner.transform.position.x + 0.1f && ObjectInScene [i].transform.position.y < ObjectSelectionner.transform.position.y + 0.1f
//					    && ObjectInScene [i].transform.position.z < ObjectSelectionner.transform.position.z + 0.1f && ObjectInScene [i].transform.position.x > ObjectSelectionner.transform.position.x - 0.1f
//						&& ObjectInScene [i].transform.position.y > ObjectSelectionner.transform.position.y - 0.1f && ObjectInScene [i].transform.position.z > ObjectSelectionner.transform.position.z - 0.1f){
//						ObjectSelectionner.transform.position = new Vector3 (PositionObject.x, PositionObject.y+1, PositionObject.z);
//						PositionObject = ObjectSelectionner.transform.position;
//						i = -1;
//						print (i);
//					}
//				}
//			}
			ObjectSelectionner.GetComponent<SphereCollider> ().enabled = false;
			ObjectSelectionner.GetComponent<BoxCollider> ().enabled = true;
			print ("fuck");
			//ObjectSelectionner.GetComponent<Renderer>().material = Basematerial;
			ObjectSelectionner.layer = 0;
			ObjectSelectionner = null;
			ObjectSelectionner.transform.position = PositionObject;
			rb = null;
			ObjectController = false;
			oneframe = true;
			impossiblePosition = false;
		}
			
		//INSTANCIATE ROTATION
		/*if (RotationDone == true && ModeRotation == true) {
			print ("mondieu");
			Basematerial = ObjectSelectionner.GetComponent<Renderer> ().material;
			Instantiate (ImageRotation, new Vector3 (ObjectSelectionner.transform.position.x, ObjectSelectionner.transform.position.y, ObjectSelectionner.transform.position.z),
						new Quaternion (0,0,0,0));
			RotationDone = false;
			PeutChangerDeMode = true;
		}*/

		//MAKETHEROTATION
		/*if (RotationToMakeObjectX != 0 || RotationToMakeObjectY != 0 || RotationToMakeObjectZ != 0) {
			RotationObject ();
		}*/


		if (oneframe == true) {
			
			timer += Time.deltaTime;
			if (timer > 0.25f) {
				oneframe = false;
				timer = 0;
			}
		}


		RaycastHit hit;
		Ray ray	= MyCamera.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
            if (hit.transform.tag == "ObjetBougeable" && ObjectController == false && oneframe == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (ModeRotation == false) {
                    print("bugpas");
                    ObjectSelectionner = hit.transform.gameObject;
                    ObjectSelectionner.GetComponent<Desactivation>().valeurmvt = 0;
                    if (ObjectSelectionner.GetComponent<Rigidbody>() != null)
                    {
                        rb = ObjectSelectionner.GetComponent<Rigidbody>();
                        }
                        if (rb.velocity.magnitude == 0)
                        {
                            PositionY = ObjectSelectionner.transform.position.y;
                            PositionObject = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                            ObjectSelectionner.layer = 2;
                            //Basematerial = ObjectSelectionner.GetComponent<Renderer> ().material;
                            ObjectController = true;
                            print("pute");
                        }
                        else
                        {
                            ObjectSelectionner = null;
                            rb = null;
                        }
                    }
                }
                if (LvlEditorBehavior.EditModeActivated == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        ObjectSelectionner = hit.transform.gameObject;
                        //Basematerial = ObjectSelectionner.GetComponent<Renderer> ().material;
                        if (ObjectSelectionner.GetComponent<Rigidbody>() != null)
                        {
                            rb = ObjectSelectionner.GetComponent<Rigidbody>();
                            rb.useGravity = false;
                        }
                        if (rb.velocity.magnitude == 0)
                        {
                            ObjectSelectionner.layer = 8;
                            ImageRotation.transform.tag = "Untagged";

                            ObjectController = true;
                            ModeRotation = true;
                            RotationDone = true;
                            oneframe = true;
                        }
                        else
                        {
                            ObjectSelectionner.layer = 0;
                            ImageRotation.transform.tag = "Untagged";
                            ObjectSelectionner = null;
                            ObjectController = false;
                            ModeRotation = false;
                            RotationDone = false;
                            oneframe = true;
                            // Basematerial = ObjectSelectionner.GetComponent<Renderer> ().material;
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (hit.transform.name == "Yaw" && oneframe == false)
                    {
                        RotationToMakeObjectY -= 90;
                        oneframe = true;
                    }
                    if (hit.transform.name == "Roll" && oneframe == false)
                    {
                        RotationToMakeObjectX += 90;
                        oneframe = true;
                    }
                    if (hit.transform.name == "Pitch" && oneframe == false)
                    {
                        RotationToMakeObjectZ += 90;
                        oneframe = true;
                    }
                }
            }
		}

		if (Input.GetKeyUp (KeyCode.Mouse0) && ObjectSelectionner != null) {
			if (impossiblePosition == false) {
				if (ObjectSelectionner.gameObject.name == "Base") {
					GameObject children = ObjectSelectionner.transform.GetChild (0).gameObject;
					children.GetComponent<BoxCollider> ().enabled = true;
				}
				valeurmvt = 0;
				ObjectSelectionner.GetComponent<SphereCollider> ().enabled = false; 
				ObjectSelectionner.GetComponent<BoxCollider> ().enabled = true;
				print ("fuck");
				//ObjectSelectionner.GetComponent<Renderer>().material = Basematerial;
				ObjectSelectionner.layer = 0;
				ObjectSelectionner = null;
				rb = null;
				ObjectController = false;
				oneframe = true;
				nombreaction += 1;
                monter = 0;
				nbaction.text = "Nb d'action : " + nombreaction;
			}
		}

        if (LvlEditorBehavior.EditModeActivated == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && ModeRotation == true && RotationDone == false && oneframe == false)
            {
                if (RotationToMakeObjectX == 0 && RotationToMakeObjectY == 0 && RotationToMakeObjectZ == 0)
                {
                    print("oui");
                    ObjectSelectionner.layer = 0;
                    ObjectSelectionner = null;
                    rb.useGravity = true;
                    rb = null;
                    ObjectController = false;
                    oneframe = true;
                    ModeRotation = false;
                }
            }
        }

            if (ObjectController == true && oneframe == false /*&& ModeRotation == false*/) {
			ApparitionObjet ();
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			PositionY -= 1;

		}
		if (PositionY < 0.5f) {
			PositionY =0.5f;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			PositionY += 1;

		}
		if (PositionY > 9.5f) {
			PositionY = 9.5f;
		}
	}


	void ApparitionObjet () {
		ObjectSelectionner.GetComponent<SphereCollider> ().enabled = true; 
		ObjectSelectionner.GetComponent<BoxCollider> ().enabled = false;

		if (ObjectSelectionner.gameObject.name == "Base") {
			GameObject children = ObjectSelectionner.transform.GetChild (0).gameObject;
			children.GetComponent<BoxCollider> ().enabled = false;
		}

		//ObjectSelectionner.GetComponent<Renderer>().material = Ghostmaterial;
		RaycastHit hit;
		Ray ray	= MyCamera.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == "PositionObjet") {
				ObjectSelectionner.transform.position = new Vector3 (hit.transform.position.x, PositionY, hit.transform.position.z);
			}
			if (hit.transform.tag == "ObjetBougeable" && hit.transform.gameObject != ObjectSelectionner.transform.gameObject || hit.transform.tag == "ObjectInScene" && hit.transform.gameObject != ObjectSelectionner.transform.gameObject) {
				if (impossiblePosition == true) {
					print ("remonter 1");
					monter += 1;
				}
				ObjectSelectionner.transform.position = new Vector3 (hit.transform.position.x, PositionY + monter, hit.transform.position.z);
				if (PositionY + monter >10) {
					monter -= 1;
				}
			} else {
				monter = 0;
			}

		}
	}

	/*void RotationObject () {

		// ROTATION Y
		if (RotationToMakeObjectY > 0) {
			float depassementY ;
			depassementY = RotationToMakeObjectY;
			ObjectSelectionner.transform.Rotate (0, -VitesseRotationObject, 0,Space.World);
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
			ObjectSelectionner.transform.Rotate (-VitesseRotationObject, 0, 0,Space.World);
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
			float depassementZ ;
			depassementZ = RotationToMakeObjectZ;
			ObjectSelectionner.transform.Rotate (0, 0, -VitesseRotationObject,Space.World);
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



		if (RotationToMakeObjectX == 0 && RotationToMakeObjectY == 0 && RotationToMakeObjectZ == 0) {
			RotationDone = true;
			print ("shit");
		}
	}*/




		
}
