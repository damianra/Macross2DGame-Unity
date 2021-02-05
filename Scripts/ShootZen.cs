using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootZen : MonoBehaviour {

	private bool disparo = false;

	private Rigidbody2D body;
	private Vector2 desplazamiento;
	public float velocidad;
	public float daño;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		desplazamiento = new Vector2 ();
	}
	
	// Update is called once per frame
	void Update () {
		desplazamiento.x = 1f * velocidad;
		body.velocity = desplazamiento;
	}
		
	public void ZenDes(){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("Valkiria") == true) {
			collision.gameObject.SendMessage ("Hurt", daño);
			Destroy (gameObject);
		}if (collision.gameObject.CompareTag ("Destructor")) {
			Destroy (gameObject);
		}
	}

	public void death(){
		Destroy (gameObject);
	}
}
