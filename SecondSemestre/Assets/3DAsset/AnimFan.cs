﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFan : MonoBehaviour {

public ParticleSystem Wind;
public int StartOrientation;
public int SalleOrientation;
<<<<<<< HEAD
private int previous, next;
public bool OnOff;
private bool isOn;
=======
public int previous;
public bool OnOff;
private bool isOn, EndTransision;
public float ParticuleRotattion;

public GlobalOrientation Script;

>>>>>>> IntegrationAssetsHugo
SkinnedMeshRenderer skin;
	// Use this for initialization
	void Start () {
		skin=GetComponent<SkinnedMeshRenderer>();
	}
	IEnumerator On(int BlendShape)
	{
<<<<<<< HEAD
		for(float i = 0f;i<100f; i=Time.deltaTime )
		{
			skin.SetBlendShapeWeight(SalleOrientation,i);

=======
		previous =BlendShape;


		for(float i = 0f;i<102f; i+=2f)
		{
			if(i==80)
		{
			//if(Wind.isPlaying==false)
			
		//	Wind.Play();
		//	print("salope");
		}

			skin.SetBlendShapeWeight(BlendShape,i);
			yield return null;		
		}			
	}
	
		IEnumerator Off(int BlendShape)
		{			
			for(float i = 100f;i>-2f; i-=2f)
		{
			skin.SetBlendShapeWeight(BlendShape,i);
			yield return null;
>>>>>>> IntegrationAssetsHugo
		}
		yield return null;
		
	}
<<<<<<< HEAD
	
		IEnumerator Off()
=======



	void ParticuleStartOrientation()
>>>>>>> IntegrationAssetsHugo
	{
		yield return null;
	}
<<<<<<< HEAD
=======

void ParticuleOrientation()
	{
		if(SalleOrientation ==0)
		{
			ParticuleRotattion =90f;
			if(ParticuleHolder.transform.localEulerAngles.y!=ParticuleRotattion)
			ParticuleHolder.transform.localEulerAngles =new Vector3(0f,ParticuleRotattion,0f);
		}
		else if(SalleOrientation ==1)
		{
			ParticuleRotattion =180f;
			if(ParticuleHolder.transform.localEulerAngles.y!=ParticuleRotattion)
			ParticuleHolder.transform.localEulerAngles =new Vector3(0f,ParticuleRotattion,0f);
		}
		else if(SalleOrientation ==2)
		{
			ParticuleRotattion =-90f;
			if(ParticuleHolder.transform.localEulerAngles.y!=ParticuleRotattion)
			ParticuleHolder.transform.localEulerAngles =new Vector3(0f,ParticuleRotattion,0f);
		}
		else if(SalleOrientation ==3)
		{
			ParticuleRotattion =0f;
			if(ParticuleHolder.transform.localEulerAngles.y!=ParticuleRotattion)
			ParticuleHolder.transform.localEulerAngles =new Vector3(0f,ParticuleRotattion,0f);
		}
	}
>>>>>>> IntegrationAssetsHugo
	

	// Update is called once per frame
	void Update () {

<<<<<<< HEAD
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
=======
		SalleOrientation =Script.CurrentOrientation;
		
	

	
		//Lance l'anim
>>>>>>> IntegrationAssetsHugo

		if(OnOff && !isOn)
		{
			StartCoroutine(On(SalleOrientation));
			isOn=true;
		//Arret pour drag n drop	
		}
<<<<<<< HEAD
=======
		if (!OnOff && isOn){
			StartCoroutine(Off(SalleOrientation));
			isOn=false;

		}
		//tansition quand on tourner la salle
		if(previous!=SalleOrientation && !EndTransision)
		{
			StartCoroutine(Off(previous));

			if(!Wind.isStopped)
			{
			Wind.Stop();
			}

			StartCoroutine(On(SalleOrientation));
			EndTransision =true;

		}
		else{
			EndTransision=false;

			if(!Wind.isPlaying)
			{
			new	WaitForSeconds(1f);
			ParticuleOrientation();
			Wind.Play();
			}

		}

	
>>>>>>> IntegrationAssetsHugo
		
	}
}
