using UnityEngine;
using System.Collections;

public class RumiCollision : MonoBehaviour {
	public int score = 0;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "sphere") {
			Destroy (other.gameObject);
			score++;
		}else if(other.tag == "blackHole"){
			Destroy (other.gameObject);
			score--;
		}
	}
}
