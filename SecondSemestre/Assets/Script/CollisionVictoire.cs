using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionVictoire : MonoBehaviour {

    public GameObject Victoire;
    float Timer = 0;
    public int ColorToHaveForWin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider col)
    {
        if (col.transform.name == "Avatar")
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;

        }
    }

    void OnTriggerStay (Collider col) {

        if (col.transform.name == "Avatar")
        {
            if (col.GetComponent<ColorFusion>().CurrentColor == ColorToHaveForWin)
            {
                col.transform.gameObject.layer = 2;
                col.transform.position = Vector3.Lerp(col.transform.position, transform.position, 0.1f);
                Timer += Time.deltaTime;
                if (Timer > 1.5)
                {
                    Victoire.SetActive(true);
                }
            }
        }
	}
}
