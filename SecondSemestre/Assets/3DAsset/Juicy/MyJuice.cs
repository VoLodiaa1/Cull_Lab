using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyJuice : MonoBehaviour {

	public AnimationCurve BounceCurve;
	public float BounceTime;
	private float timer;
	GameObject MeshObjet;
	public bool onetime;
	
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
	//	MeshObjet.transform.position = position - new Vector3 (0f,0.5f - BounceCurve.Evaluate(x) *0.5f,0f);

		
	   yield return null;
	   

	}
	MeshObjet.transform.localScale = Vector3.one;
	//MeshObjet.transform.position = position;
	
	}

IEnumerator Timer(){

	for(int i = 0; i<10 ; i++)
	{
		new WaitForSeconds(BounceTime);
		onetime=true;

		if(i==9)
		{
			onetime=false;
			break;
		}

		yield return null;
	}

 	
}
	
	void OnCollisionEnter(Collision col){
		if(!onetime){
			StartCoroutine(Bounce());
			onetime=true;
			

		}
		
	
	
	}
	
	
	// Update is called once per frame

}
