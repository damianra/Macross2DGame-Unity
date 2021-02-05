using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveShoot : MonoBehaviour {
	
	private GameObject tmp;

	private Rigidbody2D body;
	private Vector2 desplazamiento;
	public float velocidad;
	public float daño;
	public LayerMask queAtacar;
	private Transform target;
	private float movHor;
	private float movVer;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		desplazamiento = new Vector2 ();
		tmp = GameObject.FindGameObjectWithTag("Valkiria");
		if (tmp != null) {
			target = tmp.transform;
		} if(tmp == null) {
			desplazamiento = body.velocity;
			desplazamiento.x = 1f * velocidad;
			body.velocity = desplazamiento;
		} 
	}

	// Update is called once per frame
	void Update () {
		if (target) {
			if (transform.position.x > target.position.x) {
				movHor = -1f;
			} 
			if (transform.position.y < target.position.y) {
				movVer = 1f;
			}
			if (transform.position.y > target.position.y) {
				movVer = -1f;
			}
		}
	}

	void FixedUpdate(){
		desplazamiento = body.velocity;
		desplazamiento.x = movHor * velocidad;
		desplazamiento.y = movVer * velocidad;
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
