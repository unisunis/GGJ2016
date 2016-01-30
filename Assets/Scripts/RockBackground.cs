using UnityEngine;
using System.Collections;

public class RockBackground : MonoBehaviour {

	public bool right = false;
	// Use this for initialization
	void Start () {
		Vector3 swap = transform.position;
		Vector3 point = Camera.main.WorldToScreenPoint(transform.position);
		if (right) {
			swap = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, point.y, point.z));
		} else {
			swap = Camera.main.ScreenToWorldPoint (new Vector3 (0, point.y, point.z));
		}
		transform.position = swap;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
