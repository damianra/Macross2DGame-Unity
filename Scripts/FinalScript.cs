using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("volverInicio", 23f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void volverInicio(){
		SceneManager.LoadScene (0);
	}
}
