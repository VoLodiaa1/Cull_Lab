using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlEditorBehavior : MonoBehaviour {
    public GameObject SpawnPoint;
    public static bool EditModeActivated = false;
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
	
	// Update is called once per frame
	void Update () {

		
	}

    public void ObjSpawner(GameObject obj)
    {
       GameObject instObj = Instantiate(obj, SpawnPoint.transform.position, Quaternion.identity, GameObject.Find("Salle").transform);
        
        if(obj.name == "Injecteur")
        {
            instObj.GetComponent<Material>().color = InjecteurColor;
        }
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
}
