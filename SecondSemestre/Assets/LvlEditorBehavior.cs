using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlEditorBehavior : MonoBehaviour {
    public GameObject SpawnPoint;
    public static bool EditModeActivated = false;
    public Text TextEdit;
    public List<GameObject> LvlEditorButtons;
    public static Color InjecteurColor = Color.cyan;
    int ValeurCouleur;

    public static bool TrashMode = false;
    public Sprite ON;
    public Sprite OFF;
    public Text TextTrash;
    public List<GameObject> Tabs;

    
	// Use this for initialization
	void Start () {
        TextTrash.text = "Destruction Désactivé";
        EditModeActivated = false;
        TextEdit.text = "Edit Désactivé";
        foreach (var item in LvlEditorButtons)
        {
            item.SetActive(false);
        }
        foreach (var item in Tabs)
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
            instObj.GetComponent<Renderer>().material.color = InjecteurColor;
            instObj.GetComponent<Seringe>().ValeurCouleur = ValeurCouleur;
            Debug.Log(InjecteurColor);
        }
        if(obj.name == "ConditionDeVictoire")
        {
            instObj.GetComponent<VictoryEditorBehavior>().ColorVictory = InjecteurColor;
            instObj.GetComponent<CollisionVictoire>().ColorToHaveForWin = ValeurCouleur;
        }
        
        
    }

    public void EditMode()
    {
        if(EditModeActivated == true)
        {
            TrashMode = false;
            EditModeActivated = false;
            TextEdit.text = "Edit Désactivé";
            foreach (var item in LvlEditorButtons)
            {
                item.SetActive(false);
            }
            foreach (var item in Tabs)
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
            ValeurCouleur = 1;
            Debug.Log("cyan");
        }
        if (InjectColor == "magenta")
        {
            InjecteurColor = Color.magenta;
            ValeurCouleur = 2;
        }
        if (InjectColor == "yellow")
        {
            InjecteurColor = Color.yellow;
            ValeurCouleur = 3;
        }
    }

    public void Trash(GameObject target)
    {
        if (TrashMode == true)
        {
            TrashMode = false;
            TextTrash.text = "Destruction Désactivé";
            target.GetComponent<Image>().sprite = OFF;
            

        }
        else
        {
            TrashMode = true;
            TextTrash.text = "Destruction Activé";
            target.GetComponent<Image>().sprite = ON;


        }
    }

    public void ChangeTabs(GameObject tab)
    {
        foreach (var item in Tabs)
        {
            item.SetActive(false);
        }
        tab.SetActive(true);
    }
}
