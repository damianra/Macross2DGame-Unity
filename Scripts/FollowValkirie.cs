using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowValkirie : MonoBehaviour {

	public Transform target;
	public float separacion = 3f;

	private Vector3 tarPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (target) {
			tarPosition = target.position;
			tarPosition.z = -10;
			transform.position = Vector3.Lerp (transform.position, target.position, 1);
		}*/
		transform.position = new Vector3 (target.position.x, transform.position.y, transform.position.z);
	}
}
