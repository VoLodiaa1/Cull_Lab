using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFan : MonoBehaviour {

public ParticleSystem Wind;
public int StartOrientation;
public int SalleOrientation;
private int previous, next;
public bool OnOff;
private bool isOn;
SkinnedMeshRenderer skin;
	// Use this for initialization
	void Start () {
		skin=GetComponent<SkinnedMeshRenderer>();
	}
	IEnumerator On()
	{
		for(float i = 0f;i<100f; i=Time.deltaTime )
		{
			skin.SetBlendShapeWeight(SalleOrientation,i);

		}
		yield return null;
		
	}
	
		IEnumerator Off()
	{
		yield return null;
	}
	

	// Update is called once per frame
	void Update () {

		if(SalleOrientation<3)
		{
			previous =SalleOrientation;
			next =SalleOrientation+1;
		}
		else if(SalleOrientation==3)
		{
			previous =3;
			next=0;
		}

		if(OnOff && !isOn)
		{
			StartCoroutine(On());
			isOn=true;
			
		}
		
	}
}
