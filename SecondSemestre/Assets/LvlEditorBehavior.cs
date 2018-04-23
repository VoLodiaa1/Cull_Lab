using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.UI;
>>>>>>> Dev

public class LvlEditorBehavior : MonoBehaviour {
    public GameObject SpawnPoint;
    public static bool EditModeActivated = false;
<<<<<<< HEAD
	// Use this for initialization
	void Start () {
		
	}
=======
    public Text TextEdit;
    public List<GameObject> LvlEditorButtons;
    public static Color InjecteurColor;
	// Use this for initialization
	void Start () {
        EditModeActivated = false;
        TextEdit.text = "Edit Désactivé";
        foreach (var item in LvlEditorButtons)
        {
            item.SetActive(false);
        }
    }
>>>>>>> Dev
	
	// Update is called once per frame
	void Update () {

		
	}

    public void ObjSpawner(GameObject obj)
    {
       GameObject instObj = Instantiate(obj, SpawnPoint.transform.position, Quaternion.identity, GameObject.Find("Salle").transform);
        instObj.transform.tag = "ObjetBougeable";
<<<<<<< HEAD
=======
        if(obj.name == "Injecteur")
        {
            instObj.GetComponent<Material>().color = InjecteurColor;
        }
>>>>>>> Dev
        if(instObj.GetComponent<MeshRenderer>().enabled == false)
        {
            instObj.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void EditMode()
    {
        if(EditModeActivated == true)
        {
            EditModeActivated = false;
<<<<<<< HEAD
            
        }
        if (EditModeActivated == false)
        {
            EditModeActivated = true;
            
        }

    }
=======
            TextEdit.text = "Edit Désactivé";
            foreach (var item in LvlEditorButtons)
            {
                item.SetActive(false);
            }
            
        }
        else
        {
            EditModeActivated = true;
            TextEdit.text = "Edit Activé";
            foreach (var item in LvlEditorButtons)
            {
                item.SetActive(true);
            }
        }

    }

    public void PickAColor(string InjectColor)
    {
        if (InjectColor == "cyan")
        {
            InjecteurColor = Color.cyan;
            Debug.Log("cyan");
        }
        if (InjectColor == "cagenta")
        {
            InjecteurColor = Color.magenta;
        }
        if (InjectColor == "yellow")
        {
            InjecteurColor = Color.yellow;
        }
    }
>>>>>>> Dev
}
