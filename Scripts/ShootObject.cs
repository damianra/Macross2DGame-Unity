using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObject : MonoBehaviour {

	public GameObject shootPrfb;
	private bool disparo = false;
	public float ratioDisparo;

	private float time;
	private AudioSource au;
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
		GetComponent<AudioSource> ().Play ();
	}
	public void DetenerDis(){
		disparo = false;
		GetComponent<AudioSource> ().Stop ();
	}

	void Disp(){
		 Instantiate (shootPrfb, transform.position, Quaternion.identity);
		 
	}
		


}
