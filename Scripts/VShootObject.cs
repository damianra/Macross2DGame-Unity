using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VShootObject : MonoBehaviour {

	public GameObject shootPrfb;
	private bool disparo = false;
	public float ratioDisparo;

	private float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//tiempo de disparo
		time += Time.deltaTime;
		if (disparo && (time > ratioDisparo)) {
			Disp ();
			time = 0;
		}
	}

	public void Disparar(){
		disparo = true;

	}
	public void DetenerDis(){
		disparo = false;
	}

	void Disp(){
		 Instantiate (shootPrfb, transform.position, Quaternion.identity);
		GetComponent<AudioSource> ().Play ();
	}


}
