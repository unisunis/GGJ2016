using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (loading ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator loading(){
		yield return new WaitForSeconds (1);
		Application.LoadLevel (1);
	}
}
