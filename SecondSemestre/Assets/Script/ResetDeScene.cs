using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetDeScene : MonoBehaviour {

	public int NumeroScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset () {
		SceneManager.LoadScene (NumeroScene);
	}

	public void Scene1() {
		SceneManager.LoadScene (0);
	}

	public void Scene2() {
		SceneManager.LoadScene (1);
	}
	public void Scene3() {
		SceneManager.LoadScene (2);
	}
}
