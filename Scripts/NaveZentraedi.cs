using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveZentraedi : MonoBehaviour {

	public Transform detectarTecho;
	public Transform detectarPiso;
	public LayerMask objTecho;
	public LayerMask objPiso;

	private bool tocaTecho;
	private bool tocaPiso;

	private Rigidbody2D body;
	public float velocidad = 1f;
	public int puntos;
	private Vector2 movimiento;

	private Animator anim;

	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public GameObject obj6;
	public GameObject obj7;
	private Collider2D coll;
	private AudioSource au;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		coll = GetComponent<Collider2D> ();
		body = GetComponent<Rigidbody2D>();
		au = GetComponent<AudioSource> ();
		movimiento = new Vector2 ();
		tocaTecho = false; 
		tocaPiso = true;

		obj1.SetActive (false);
		obj2.SetActive (false);
		obj3.SetActive (false);
		obj4.SetActive (false);
		obj5.SetActive (false);
		obj6.SetActive (false);
		obj7.SetActive (false);
		coll.enabled = false;

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

	void FixedUpdate(){
		movimiento = body.velocity;
		if (tocaTecho) {
			movimiento.y = -2f * velocidad;
		}
		if (tocaPiso) {
			movimiento.y = 2f * velocidad;
		}
		body.velocity = movimiento;
		Invoke ("EmpezarFinal", 1.5f);
	}

	void death(){
		au.Play ();
		GetComponent<Collider2D> ().enabled = false;
		Puntuacion.current.Addpuntuacion (puntos);
		Destroy (gameObject);
		Puntuacion.current.FinalGame ();
	}

	void EmpezarFinal(){
		anim.SetBool ("aparecio", true);
		obj1.SetActive (true);
		obj2.SetActive (true);
		obj3.SetActive (true);
		obj4.SetActive (true);
		obj5.SetActive (true);
		obj6.SetActive (true);
		obj7.SetActive (true);
		coll.enabled = true;
	}
		
}
