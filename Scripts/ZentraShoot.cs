using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZentraShoot : MonoBehaviour {

	public GameObject shootPrfb;
	public float ratioDisparo;

	private float time;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
			if (time > ratioDisparo) {
				Disp ();
				time = 0;
		}

	}

	void Disp(){
		Instantiate (shootPrfb, transform.position, Quaternion.identity);
	}

		

}
