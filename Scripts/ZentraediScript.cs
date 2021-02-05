using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZentraediScript : MonoBehaviour {

	private Rigidbody2D body;
	public GameObject zenShoot;
	public float velocidad = 1f;
	public int puntos;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		transform.Translate (Vector3.left * Time.deltaTime * velocidad);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("Valkiria") == true) {
			zenShoot.SetActive (false);
			this.GetComponent<AudioSource> ().Play ();
			anim.SetBool ("Explosion", true);
			Invoke ("ZenDes", 1.8f);
		}
	}

	void ZenDead(){
		Destroy (gameObject);
	}

	public void ZenDes(){
		Destroy (gameObject);
	}

	void death(){
		zenShoot.SetActive (false);
		GetComponent<Collider2D> ().enabled = false;
		this.GetComponent<AudioSource> ().Play ();
		anim.SetBool ("Explosion", true);
		Puntuacion.current.Addpuntuacion (puntos);
		Invoke ("ZenDead", 1.8f);
	}

}


