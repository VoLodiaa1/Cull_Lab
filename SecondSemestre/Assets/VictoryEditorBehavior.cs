using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryEditorBehavior : MonoBehaviour {
    public BoxCollider ColliderGame;
    public BoxCollider ColliderEditor;
    public Color ColorVictory;

    GameObject TempColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (LvlEditorBehavior.EditModeActivated == false)
        {
            gameObject.tag = "ObjectInScene";
            ColliderGame.enabled = true;
            ColliderEditor.enabled = false;
            
                GetComponent<MeshRenderer>().enabled = false;
            
        }
        else
        {
            gameObject.tag = "ObjetBougeable";
            ColliderGame.enabled = false;
            ColliderEditor.enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
        if (TempColor != null)
        {
            TempColor.GetComponent<ColorationCase>().ColorOfTile = Color.white;
        }
            RaycastHit Hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out Hit, Mathf.Infinity);
        if(Hit.transform.tag == "PositionObjet")
        {
            
            Hit.transform.GetComponent<ColorationCase>().ColorOfTile = ColorVictory;
            TempColor = Hit.transform.gameObject;
        }
        else
        {
           
        }
    }

   
}
