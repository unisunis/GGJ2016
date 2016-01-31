using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public GameObject hintSprite;
	public GameObject[] obstacle;
	private bool hint = true;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && hint) {
			hint = false;
			GetComponent<BoxCollider2D> ().enabled = false;
			hintSprite.GetComponent<Animator> ().enabled = true;
		} else if (other.tag == "Player") {
			foreach (GameObject obs in obstacle) {
				if (obs.tag == "Particule") {
					obs.SetActive (true);
				} else {
					obs.GetComponent<Animator> ().enabled = true;
				}
			}
		}
	}
}
