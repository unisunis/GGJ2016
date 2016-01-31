using UnityEngine;
using System.Collections;

public class ToThelimiteYouGo : MonoBehaviour {

	public bool right = false;

	void Start(){
		Vector3 swap = transform.position;
		Vector3 point = Camera.main.WorldToScreenPoint (transform.position);
		if (right) {
			swap = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, point.y, point.z));
		} else {
			swap = Camera.main.ScreenToWorldPoint (new Vector3 (0, point.y, point.z));
		}
		transform.position = swap;
	}
}
