using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float hp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hurt(float daño){
		hp -= daño;
		if (hp <= 0) {
			gameObject.SendMessage ("death");
		}
	}
}
