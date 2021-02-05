using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.CompareTag ("ValkShoot")) {
			collision.gameObject.SendMessage ("ShootDes");
		} else {
			
		} 
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("ValkShoot")) {
			collision.gameObject.SendMessage ("ShootDes");
		}if (collision.gameObject.CompareTag ("ZenShoot")) {
			collision.gameObject.SendMessage ("ZenDes");
		}
	}
}
