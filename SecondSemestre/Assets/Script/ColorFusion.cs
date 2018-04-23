using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorFusion : MonoBehaviour {

    GameObject Masalle;
    public int CurrentColor =0;
    public Color ColorLerped = Color.white;

        // Les couleurs possibles dans votre jeux, avec les couleurs primaires, secondaires, etc.
        Color[] colors = new Color[] {
        Color.white,
        Color.cyan,
        Color.magenta,
        Color.yellow,
        Color.blue,
        Color.red,
        Color.green,
        Color.black,
	};

    // Tous les mélanges possibles. Les valeurs sont en réalité l'index de la couleur dans le tableau "colors"
    int[,] colorMatrix = new int[,]
    {
        {0,1,2,3,4,5,6,7},
        {1,-1,4,6,-1,7,-1,-1},
        {2,4,-1,5,-1,-1,7,-1},
        {3,6,5,-1,7,-1,-1,-1},
        {4,-1,-1,7,-1,-1,-1,-1},
        {5,7,-1,-1,-1,-1,-1,-1},
        {6,-1,7,-1,-1,-1,-1,-1},
        {7,-1,-1,-1,-1,-1,-1,-1}
    };

    // -- //
    private void Start()
    {
        Masalle = GameObject.Find("Salle");
    }



    // Renvoi juste la couleur à la position donnée
    int Merge(int color1, int color2) {
		return colorMatrix[color1, color2];
	}
	
	// -- //
	
	void Awake() {
		
		
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (LvlEditorBehavior.EditModeActivated == false)
        {
            if (other.transform.name.Contains("seringe") && Masalle.GetComponent<PositionnementObjet>().ObjectController == false)
            {
                print("fusion");
                int colorID = Merge(CurrentColor, other.transform.GetComponent<Seringe>().ValeurCouleur);

                if (colorID != -1)
                {
                    Color ColorToGo = colors[colorID];
                    Color ActualColor = colors[CurrentColor];
                    GameObject parent = other.gameObject.transform.parent.gameObject;

                    if (ColorToGo != GetComponent<Renderer>().material.color)
                    {

                        GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, ColorToGo, 0.1f);
                        print("coloring");
                    }
                    else
                    {
                        CurrentColor = colorID;
                        parent.GetComponent<UseGravity>().injecteurDone = true;
                        parent.GetComponent<BoxCollider>().enabled = false;
                        other.GetComponent<BoxCollider>().enabled = false;
                    }
                }
            }
        }
    }

}
