using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarDesactivar : MonoBehaviour {

	public GameObject pausa;
	public GameObject play;

	public GameObject camara;
	private AudioSource auCamara;

	// Use this for initialization
	void Start () {
		auCamara = camara.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void btnPlay(){
		Time.timeScale = 1.0f;
		auCamara.Play ();
		pausa.SetActive(true);
		play.SetActive(false);
	}

	public void btnPausa(){
		auCamara.Pause ();
		Time.timeScale = 0.0f;
		pausa.SetActive(false);
		play.SetActive(true);
	}
}
