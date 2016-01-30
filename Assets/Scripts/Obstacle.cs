using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private bool hint = true;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && hint) {
			print ("loula");
			hint = false;
			GetComponent<BoxCollider2D> ().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = true;
		} else if (other.tag == "Player") {
			print ("thenia");
			//GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
