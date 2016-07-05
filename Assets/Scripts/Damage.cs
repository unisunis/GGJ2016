using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	private bool firstTime = true;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" & firstTime) {
			other.GetComponent<SwipeScript> ().takeHitCall ();
			firstTime = false;

			/*Vector3 startingPosition = GameObject.FindGameObjectWithTag ("startingPoint").transform.position;
			GameObject ascenscionField = GameObject.FindGameObjectWithTag ("ascensionField");
			Vector3 swap = ascenscionField.transform.position;
			swap = startingPosition;
			ascenscionField.transform.position = swap;*/
		}
	}


}
