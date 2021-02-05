using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meltran : MonoBehaviour {

	public Transform detectarTecho;
	public Transform detectarPiso;
	public LayerMask objTecho;
	public LayerMask objPiso;

	private bool tocaTecho;
	private bool tocaPiso;

	private Rigidbody2D body;
	public GameObject zenShoot;
	public GameObject zenShootM;
	public float velocidad = 1f;
	public int puntos;
	private Vector2 movimiento;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D>();
		movimiento = new Vector2 ();
		tocaTecho = false; 
		tocaPiso = true;
	}

	void FixedUpdate(){
		movimiento = body.velocity;
		movimiento.x = -0.5f * velocidad;
		if (tocaTecho) {
			movimiento.y = -2f * velocidad;
		}
		if (tocaPiso) {
			movimiento.y = 2f * velocidad;
		}if(anim.GetBool("Explosion")){
			movimiento.x = 0f * velocidad;
			movimiento.y = 0f * velocidad;
		}
		body.velocity = movimiento;
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics2D.OverlapCircle (detectarTecho.position, 0.02f, objTecho)) {
			tocaTecho = true;
			tocaPiso = false;
		} else if (Physics2D.OverlapCircle (detectarPiso.position, 0.02f, objPiso)) {
			tocaPiso = true;
			tocaTecho = false;
		}
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("Valkiria") == true) {
			ZenDead ();
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
		zenShootM.SetActive (false);
		GetComponent<Collider2D> ().enabled = false;
		this.GetComponent<AudioSource> ().Play ();
		anim.SetBool ("Explosion", true);
		Invoke ("ZenDead", 1.8f);
		Puntuacion.current.Addpuntuacion (puntos);
	}

}


