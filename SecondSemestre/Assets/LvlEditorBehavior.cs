using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlEditorBehavior : MonoBehaviour {
    public GameObject SpawnPoint;
    public static bool EditModeActivated = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void ObjSpawner(GameObject obj)
    {
       GameObject instObj = Instantiate(obj, SpawnPoint.transform.position, Quaternion.identity, GameObject.Find("Salle").transform);
        instObj.transform.tag = "ObjetBougeable";
        if (instObj.GetComponent<MeshRenderer>() != null)
        {
            if (instObj.GetComponent<MeshRenderer>().enabled == false)
            {
                instObj.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

    public void EditMode()
    {
        if(EditModeActivated == true)
        {
            EditModeActivated = false;
            
        }
        if (EditModeActivated == false)
        {
            EditModeActivated = true;
            
        }

    }
}
