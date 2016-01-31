using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	private bool firstTime = true;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" & firstTime) {
			print ("dharbou");
		}
	}
}
