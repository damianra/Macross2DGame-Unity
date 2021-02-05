using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject nave;
	public GameObject zentraedi;
	public GameObject zentraedi2;
	public GameObject zentraedi3;
	public int zentraLimit;

	private float time;
	public float timeToSpawn;
	private float zentraCount;

	// Use this for initialization
	void Start () {
		time = 0;
	}

	void OnEnable(){
		zentraCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > timeToSpawn) {
			time = 0;
			int rnd = Random.Range (0, 5);
			if (rnd == 3) {
				Instantiate (zentraedi, transform.position, Quaternion.identity);
			} else if(rnd == 4){
				Instantiate (zentraedi3, transform.position, Quaternion.identity);
			}else {
				Instantiate (zentraedi2, transform.position, Quaternion.identity);
			}


			zentraCount++;
			if (zentraCount >= zentraLimit) {
				gameObject.SetActive (false);
				if (nave == null) {
				
				} else {
					Invoke ("InvocarNave", 5f);
				}

			}
		}
	}

	void InvocarNave(){
		nave.SetActive (true);
	}

}
