using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValkirieScript : MonoBehaviour {

	public GameObject shootValkiria;
	public GameObject shootFigther;
	public GameObject shootBattleroid;

	public GameObject collFigther;
	public GameObject collBattroid;
	public GameObject misil;

	public float speed;

	private Rigidbody2D body; 

	private bool derecha = false;
	private bool izquierda = false;
	private bool arriba = false;
	private bool abajo = false;

	private Vector2 posAtt;
	private Animator anim;
	private Collider2D collValkiria;
	private AudioSource auDeath;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		collValkiria = GetComponent<Collider2D> ();
		auDeath = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () { 

		if (derecha) {
			transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
		if (izquierda) {
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
		if (arriba) {
			transform.Translate (Vector3.up * Time.deltaTime * speed);
		}
		if (abajo) {
			transform.Translate (Vector3.down * Time.deltaTime * speed);
		}
			
		}

			

	//================ Funciones Publicas de Movimiento ================
	public void MoverDerecha(){
		derecha = true;
	}

	public void MoverIzquierda(){
		izquierda = true;
	}

	public void MoverArriba(){
		arriba = true;
	}

	public void MoverAbajo(){
		abajo = true;
	}

	public void Detener(){
		derecha = false;
		izquierda = false;
		arriba = false;
	    abajo = false;
	}


	// ==== Seleccionar animacion dependiendo en que estado se encuentra ====
	public void Transform1(){
		if (anim.GetBool ("FigthMode") && (anim.GetBool ("BattleroidMode") == false)) {
			Invoke ("battleroid", 0.3f);
		}else if((anim.GetBool ("BattleroidMode") == true) && anim.GetBool ("ValkiriaMode") == false){
			Invoke ("valkiria", 0.3f);

		} else if((anim.GetBool ("ValkiriaMode") == true) && (anim.GetBool ("FigthMode") == false)){
			Invoke ("figther", 0.3f);
		}

	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.CompareTag ("zentraedi") == true) {
			death ();
		}
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("zentraedi") == true) {
			death ();
		}
	}

	public void death(){
		collFalse ();
		auDeath.Play ();
		anim.SetBool ("Explosion", true);
		Invoke ("fin", 1.8f);
	}
		
	void collFalse(){
		collValkiria.enabled = false;
		collBattroid.SetActive (false);
		collFigther.SetActive (false);
		shootValkiria.SetActive (false);
		shootFigther.SetActive (false);
		shootBattleroid.SetActive (false);
	}

	void valkiria(){
		anim.SetBool ("FigthMode", false);
		anim.SetBool ("BattleroidMode", false);
		anim.SetBool ("ValkiriaMode", true);
		shootBattleroid.SetActive (false);
		shootValkiria.SetActive (true);
		collBattroid.SetActive (false);
		collValkiria.enabled = true;
		misil.SetActive (true);
	}

	void figther(){
		anim.SetBool ("FigthMode", true);
		anim.SetBool ("ValkiriaMode", false);
		anim.SetBool ("BattleroidMode", false);
		shootValkiria.SetActive (false);
		shootFigther.SetActive (true);
		collValkiria.enabled = false;
		collFigther.SetActive(true);
		misil.SetActive (false);
	}

	void battleroid(){
		anim.SetBool ("ValkiriaMode", false);
		anim.SetBool ("FigthMode", false);
		anim.SetBool ("BattleroidMode", true);
		shootFigther.SetActive (false);
		shootBattleroid.SetActive (true);
		collFigther.SetActive (false);
		collBattroid.SetActive (true);
		misil.SetActive (false);
	}

	void fin(){
		Destroy (gameObject);
		Puntuacion.current.GameOver ();
	}

	}


