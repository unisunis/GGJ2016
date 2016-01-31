using UnityEngine;
using System.Collections;

public class CloudGenerator : MonoBehaviour {

	private bool instantiate = false;
	public GameObject[] clouds;

	void OnBecameVisible () {
		if (!instantiate && false) {
			int margin = Random.Range (0, 50);
			int selectedCloud = 1;//Random.Range (0, clouds.Length);
			Vector3 point = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 cloudPosition = Camera.main.ScreenToWorldPoint(new Vector3(0,0 , point.z));
			Instantiate (clouds[selectedCloud], cloudPosition, Quaternion.identity);
			instantiate = true;
		}
	}

	void OnBecameInvisible(){
		if (instantiate) {
			Destroy (gameObject);
		}
	}

}


	
