using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private bool hint = true;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && hint) {
			hint = false;
			GetComponent<BoxCollider2D> ().enabled = false;
			GetComponent<Animator> ().enabled = true;
		} else if (other.tag == "Player") {
			print ("thenia");
			//GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
