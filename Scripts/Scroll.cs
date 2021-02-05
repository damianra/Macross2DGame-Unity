using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	public float velocidad = 0f;

	private bool comJuego = false;
	private float tInicio = 0f;

	// Use this for initialization
	void Start () {
	//	NotificationCenter.DefaultCenter ().AddObserver (this, "ComienzaJuego");
	}

/*	void ComienzaJuego(){
		comJuego = true;
		tInicio = Time.time;
	}*/
	
	// Update is called once per frame
	void Update () {

			Renderer ren = GetComponent<Renderer> ();
			ren.material.mainTextureOffset = new Vector2 ((Time.time* velocidad) % 1, 0);

	}
}
