using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthValk : MonoBehaviour {

	public float hp;
	private float healt;
	Health valkHp;

	// Use this for initialization
	void Start () {
		valkHp = GameObject.Find ("Valkiria").GetComponent<Health> ();
		hp = valkHp.hp;
	}
	
	// Update is called once per frame
	void Update () {
		valkHp.hp = hp;
	}

	public void Hurt(float daño){
		hp -= daño;
		if (hp <= 0) {
			GameObject.Find ("Valkiria").SendMessage ("death");
		}
	}
}
