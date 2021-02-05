using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMisile : MonoBehaviour {

	public GameObject PrfbMisil;
	private bool disparo = false;
	public float ratioDisparo;
	public int cantMisiles;
	private float time;

	public GameObject tmp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (cantMisiles == 0) {
			
		} else {
			if (disparo && (time > ratioDisparo)) {
				Disp ();
				cantMisiles--;
				time = 0;
			}
		}
	}

	public void Disparar(){
		disparo = true;
	}
	public void DetenerDis(){
		disparo = false;
	}

	void Disp(){
		
		tmp = GameObject.FindGameObjectWithTag ("zentraedi");
		if (tmp != null) {
			Instantiate (PrfbMisil, transform.position, Quaternion.identity);
		}
	}
}
