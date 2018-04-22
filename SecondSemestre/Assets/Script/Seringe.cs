using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seringe : MonoBehaviour {

	public Color MaCouleur;
	public float h, s,v;
	public int numeroSeringe;

	// Use this for initialization
	void Start () {
		MaCouleur = GetComponent<Renderer> ().material.color;
		Color.RGBToHSV (MaCouleur,out h,out s,out v);
	}
	
	// Update is called once per frame
	void Update () {
		MaCouleur = GetComponent<Renderer> ().material.color;
	}
}
