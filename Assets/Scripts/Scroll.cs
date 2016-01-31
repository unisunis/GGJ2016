using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	
	public float horizentalSpeed =.05f; // .05f fast & .02f slow
	public float verticalSpeed = 0;
	private bool started = false;

	// Use this for initialization
	void OnBecameVisible () {
		if (!started) {
			StartCoroutine(scrollIt());
			started = true;
		}
	
	}
	
	IEnumerator scrollIt(){
		yield return new WaitForSeconds (0.03f);
		transform.Translate(new Vector3(horizentalSpeed, -verticalSpeed, 0));
		StartCoroutine (scrollIt ());
	}
}
