using UnityEngine;
using System.Collections;

public class GameEnding : MonoBehaviour {

	public GameObject title;
	private bool ended = false;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" & !ended) {
			//other.GetComponent<SwipeScript> ().takeHitCall ();
			GameObject.FindGameObjectWithTag("ascensionField").GetComponent<MovementControle>().movementSpeed = .0f;
			title.SetActive (true);
			ended = false;
		}
	}
}
