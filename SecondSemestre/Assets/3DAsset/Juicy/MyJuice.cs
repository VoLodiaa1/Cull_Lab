using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyJuice : MonoBehaviour {

	public AnimationCurve BounceCurve;
	public float BounceTime;
	private float timer;
	GameObject MeshObjet;
	
	private Vector3 startScale;
	// Use this for initialization
	void Start () 
	{
		MeshObjet =transform.GetChild(0).gameObject;
		startScale =MeshObjet.transform.localScale;
	}

IEnumerator Bounce(){
	timer = Time.time;
	Vector3 position = transform.position;

	while(Time.time -timer < BounceTime)
	{
		float x = (Time.time - timer)/BounceTime;
		
		MeshObjet.transform.localScale = new Vector3(1.5f - BounceCurve.Evaluate(x)*0.5f,BounceCurve.Evaluate(x),1.5f - BounceCurve.Evaluate(x)*0.5f);
		MeshObjet.transform.position = position - new Vector3 (0f,0.5f - BounceCurve.Evaluate(x) *0.5f,0f);

		
	   yield return null;
	}
	MeshObjet.transform.localScale = Vector3.one;
	MeshObjet.transform.position = position;
		
	}

	void OnMouseEnter()
	{
		StartCoroutine(Bounce());
	}
	
	void OnCollisionEnter(Collision col){
		StartCoroutine(Bounce());
	
	
	}
	
	
	// Update is called once per frame

}
