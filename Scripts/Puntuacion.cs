using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puntuacion : MonoBehaviour {
	public static Puntuacion current;
	public Text puntuacionText;
	private int puntuacion;

	public GameObject panel;
	public Text puntDead;
	public Text puntDeadMax;
	public GameObject valkiria;

	public GameObject panelFinal;
	public Text puntFinal;
	public GameObject naveZentraedi;
	public GameObject supPunt;

	void Awake(){
		Puntuacion.current = this;
	}

	// Use this for initialization
	void Start () {
		puntuacion = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void UpdatePuntText(){
		puntuacionText.text ="Puntos: " + puntuacion;
	}

	public void Addpuntuacion(int puntos){
		puntuacion += puntos;
		UpdatePuntText ();
	}

	public void GameOver(){
				panel.SetActive (true);
				puntDead.text = "Puntuacion: " + puntuacion;
				puntDeadMax.text = "Puntuacion Maxima: " + EstadoJuego.estadoJuego.puntuacionMaxima;
				Time.timeScale = 0.0f;
				if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima) {
					EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
					EstadoJuego.estadoJuego.Guardar ();
				} else {

				}	
	}

	public void FinalGame(){
		if (valkiria) {
			panelFinal.SetActive (true);
			puntFinal.text = "Puntuacion: " + puntuacion;
			if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima) {
				EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
				EstadoJuego.estadoJuego.Guardar ();
				supPunt.SetActive (true);
			} else {

			}
		}

	}

	public void ReloadScene(){
		SceneManager.LoadScene (1);
		Time.timeScale = 1.0f;
	}

	public void CargarEscenaFinal(){
		SceneManager.LoadScene (2);
	}


}
