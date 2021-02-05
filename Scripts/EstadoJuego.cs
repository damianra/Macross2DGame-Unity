using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class EstadoJuego : MonoBehaviour {

	public int puntuacionMaxima = 0;
	private string rutaArchivo;

	public static EstadoJuego estadoJuego;


	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/data.dat";
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} else if (estadoJuego != this) {
		//	Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (rutaArchivo);

		DatosAGuardar datos = new DatosAGuardar();
		datos.puntuacionMaxima = puntuacionMaxima;
		bf.Serialize (file, datos);
		file.Close ();
	}

	void Cargar(){
		if (File.Exists (rutaArchivo)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (rutaArchivo, FileMode.Open);

			DatosAGuardar datos = (DatosAGuardar)bf.Deserialize (file);
			puntuacionMaxima = datos.puntuacionMaxima;
			file.Close ();
		} else {
			puntuacionMaxima = 0;
		}
	}

	[Serializable]
	class DatosAGuardar{
		public int puntuacionMaxima;
	}

}
