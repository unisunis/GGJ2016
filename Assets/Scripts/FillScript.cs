using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float goldenRation = 1 / (Screen.width / (GetComponent<SpriteRenderer> ().sprite.rect.size.x) );
		Vector3 swap = transform.localScale;
		swap = new Vector3 (goldenRation, goldenRation, goldenRation);
		transform.localScale = swap;

		print ("##################################");
		print (Screen.width);
		print (GetComponent<SpriteRenderer> ().sprite.rect.size.x);
		print (Screen.width / (GetComponent<SpriteRenderer> ().sprite.rect.size.x));
		print (goldenRation);
		print (goldenRation * Screen.width / (GetComponent<SpriteRenderer> ().sprite.rect.size.x));
		print (GetComponent<SpriteRenderer> ().sprite.rect.size);


		Vector3 swapPosition = transform.position;
		Vector3 point = Camera.main.WorldToScreenPoint(transform.position);
		swapPosition = Camera.main.ScreenToWorldPoint (new Vector3 (point.x, 0, point.z));
		transform.position = swapPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
