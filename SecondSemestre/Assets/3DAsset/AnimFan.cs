using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFan : MonoBehaviour {

public ParticleSystem Wind;
public GameObject ParticuleHolder;
public int StartOrientation;
public int SalleOrientation;
public int previous, next;
public bool OnOff,right, left;
private bool isOn;
public float ParticuleRotattion;

SkinnedMeshRenderer skin;
	// Use this for initialization
	void Start () {
		skin=GetComponent<SkinnedMeshRenderer>();
		ParticuleStartOrientation();
		Wind.Pause();
	}
	IEnumerator On()
	{
		for(float i = 0f;i<102f; i+=2f)
		{
			skin.SetBlendShapeWeight(StartOrientation,i);
			yield return null;
		}			
	}
	
		IEnumerator Off()
		{	
			if(Wind.isStopped==false)
			Wind.Stop();

			for(float i = 100f;i>0f; i-=2f)
		{
			skin.SetBlendShapeWeight(StartOrientation,i);
			yield return null;
		}
	}

	IEnumerator ChangementOrientation()
	{	
		for(float i = 0f;i<102f; i+=2f)
		{
			skin.SetBlendShapeWeight(next,i);
			yield return null;
		}			

			for(float i = 100f;i>0f; i-=2f)
		{
			skin.SetBlendShapeWeight(previous,i);
			yield return null;
		}

	}

	void ParticuleStartOrientation()
	{
		if(StartOrientation ==0)
		{
			ParticuleRotattion =90f;
			if(ParticuleHolder.transform.localEulerAngles.y!=ParticuleRotattion)
			ParticuleHolder.transform.localEulerAngles =new Vector3(0f,ParticuleRotattion,0f);
		}
		else if(StartOrientation ==1)
		{
			ParticuleRotattion =180f;
			if(ParticuleHolder.transform.localEulerAngles.y!=ParticuleRotattion)
			ParticuleHolder.transform.localEulerAngles =new Vector3(0f,ParticuleRotattion,0f);
		}
		else if(StartOrientation ==2)
		{
			ParticuleRotattion =-90f;
			if(ParticuleHolder.transform.localEulerAngles.y!=ParticuleRotattion)
			ParticuleHolder.transform.localEulerAngles =new Vector3(0f,ParticuleRotattion,0f);
		}
		else if(StartOrientation ==3)
		{
			ParticuleRotattion =0f;
			if(ParticuleHolder.transform.localEulerAngles.y!=ParticuleRotattion)
			ParticuleHolder.transform.localEulerAngles =new Vector3(0f,ParticuleRotattion,0f);
		}
	}

	

	// Update is called once per frame
	void Update () {
		//ParticuleOrientation();
		if(right)
		{
			if(SalleOrientation>0 && SalleOrientation<3)
			{
				SalleOrientation +=1;
				previous =SalleOrientation -1;
				next =SalleOrientation+1;

			}else{
				SalleOrientation =3;
				previous =SalleOrientation;
				next =0;
			}
			if(OnOff)
			StartCoroutine(ChangementOrientation());
			right=false;
		
				
		}
		if(left)
		{
			StartCoroutine(ChangementOrientation());
			left=false;


		}
	

		if(OnOff && !isOn)
		{
			StartCoroutine(On());
			isOn=true;
			
		}
		if (!OnOff && isOn){
			StartCoroutine(Off());
			isOn=false;

		}

		if(skin.GetBlendShapeWeight(StartOrientation)==100)
		{
			if(Wind.isPlaying==false)
			Wind.Play();

		}
		
	}
}
