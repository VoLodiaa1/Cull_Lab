using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarEditorBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (LvlEditorBehavior.EditModeActivated == false)
        {
            gameObject.tag = "ObjectInScene";
        }
        else
        {
            gameObject.tag = "ObjetBougeable";
        }
	}
}
