using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootMisil : MonoBehaviour {
	private GameObject tmp;
	private ShootMisile misilD;
	private Transform target2;
	private GameObject tmp1;

	private Rigidbody2D body;
	private Vector2 desplazamiento;
	public float velocidad;
	public float daño;
	public LayerMask queAtacar;
	private Transform target;
	private float movHor;
	private float movVer;
	private Animator anim;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		desplazamiento = new Vector2 ();
		anim = GetComponent<Animator> ();
		tmp = GameObject.FindGameObjectsWithTag("zentraedi").OrderBy(go=> Vector3.Distance(go.transform.position, transform.position)).FirstOrDefault();

		if (tmp != null) {
			target = tmp.transform;
		} else {
			tmp1 = GameObject.FindGameObjectsWithTag("zentraedi").OrderBy(go=> Vector3.Distance(go.transform.position, transform.position)).FirstOrDefault();
			target = tmp1.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			if (transform.position.x < target.position.x) {
				movHor = 1f;
			}
			/*if (transform.position.x > target.position.x) {
				movHor = -1f;
			}*/
			if (transform.position.y < target.position.y) {
				movVer = 1f;
			}
			if (transform.position.y > target.position.y) {
				movVer = -1f;
			}
		} else {
			tmp1 = new GameObject ();
			tmp1 = GameObject.FindGameObjectsWithTag("zentraedi").OrderBy(go=> Vector3.Distance(go.transform.position, transform.position)).FirstOrDefault();
			target = tmp1.transform;
			if (target) {
				if (transform.position.x < target.position.x) {
					movHor = 1f;
				}
				/*if (transform.position.x > target.position.x) {
					movHor = -1f;
				}*/
				if (transform.position.y < target.position.y) {
					movVer = 1f;
				}
				if (transform.position.y > target.position.y) {
					movVer = -1f;
				}
			} else {
			}
		}


	}

	void FixedUpdate(){
		
		desplazamiento = body.velocity;
		desplazamiento.x = movHor * velocidad;
		desplazamiento.y = movVer * velocidad;
		body.velocity = desplazamiento;

	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("zentraedi") == true) {
			collision.gameObject.SendMessage ("Hurt", daño);
			Destroy (gameObject);
		}
		if (collision.gameObject.CompareTag ("Jefe") == true) {
			collision.gameObject.SendMessage ("Hurt", daño);
			Destroy (gameObject);
		}
	}

	public void ShootDes(){
		Destroy (gameObject);
	}

	/*void RastrearObjetivo(){
		if (target) {
			if (transform.position.x < target.position.x) {
				movHor = 1f;
			}
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
	}*/
}
