using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarJuego : MonoBehaviour {
	private AudioSource sonido;
	// Use this for initialization
	void Start () {
		sonido = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargarScene(){
		sonido.Play ();
		SceneManager.LoadScene (1);
	}
}
