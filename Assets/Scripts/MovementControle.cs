using UnityEngine;
using System.Collections;

public class MovementControle : MonoBehaviour {

	public float movementSpeed = 0.01f;

	// Use this for initialization
	void Start () {
		StartCoroutine (upYouGo ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator upYouGo(){
		yield return new WaitForSeconds (0.03f);
		transform.Translate (Vector3.up * movementSpeed);
		StartCoroutine (upYouGo ());
	}
}
