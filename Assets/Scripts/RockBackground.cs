using UnityEngine;
using System.Collections;

public class RockBackground : MonoBehaviour {

	private bool instantiate = false;
	// Use this for initialization

	void OnBecameVisible () {
		if (!instantiate) {
			Instantiate (gameObject, transform.position + new Vector3(0,GetComponent<SpriteRenderer> ().bounds.size.y,0), Quaternion.identity);
			instantiate = true;
		}
	}

	void OnBecomeInvisible(){
		if (instantiate) {
			Destroy (gameObject);
		}
	}

}
