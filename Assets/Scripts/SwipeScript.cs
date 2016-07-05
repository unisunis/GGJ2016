using System.Collections;
using System;
using System.Reflection;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SwipeScript : MonoBehaviour, IEventSystemHandler{

	public GameObject aura;
	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;

	public delegate void swipeHandler();

	public  event swipeHandler swipeRightEvent;
	public  event swipeHandler swipeLeftEvent;
	public  event swipeHandler swipeUpEvent;
	public  event swipeHandler swipeDownEvent;


	[SerializeField]
	private UnityEvent m_onSwipeLeft = new UnityEvent();
	[SerializeField]
	private UnityEvent m_onSwipeRight = new UnityEvent();
	[SerializeField]
	private UnityEvent m_onSwipeUp = new UnityEvent();
	[SerializeField]
	private UnityEvent m_onSwipeDown = new UnityEvent();



	/*void OnEnable()
	{
		/swipeRightEvent += m_onSwipeRight;
		swipeLeftEvent += m_onSwipeLeft;
		swipeUpEvent += m_onSwipeUp;
		swipeDownEvent += m_onSwipeDown;
	}


	void OnDisable()
	{
		swipeRightEvent -= m_onSwipeRight;
		swipeLeftEvent -= m_onSwipeLeft;
		swipeUpEvent -= m_onSwipeUp;
		swipeDownEvent -= m_onSwipeDown;
	}*/

	void Start(){
		gameObject.GetComponent<_2dxFX_PlasmaShield> ().enabled = false;
		gameObject.GetComponent<_2dxFX_Lightning> ().enabled = false;
	}

	public void takeHitCall(){
			StartCoroutine(takeHit ());
	}
		
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0){

			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began :
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;

				case TouchPhase.Canceled :
					/* The touch is being canceled */
					isSwipe = false;
					break;

				case TouchPhase.Ended :

					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;

					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;

						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}else{
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}

						if(swipeType.x != 0.0f){
							if(swipeType.x > 0.0f){
								// MOVE RIGHT
								//swipeRightEvent();
								m_onSwipeLeft.Invoke();
							}else{
								// MOVE LEFT
								m_onSwipeRight.Invoke();
							}
						}

						if(swipeType.y != 0.0f ){
							if(swipeType.y > 0.0f){
								// MOVE UP
								m_onSwipeUp.Invoke();
							}else{
								// MOVE DOWN
								m_onSwipeDown.Invoke();
							}
						}

					}

					break;
				}
			}
		}





		// for mac

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			m_onSwipeUp.Invoke();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			m_onSwipeDown.Invoke();
		}else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			m_onSwipeRight.Invoke();
		}else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			m_onSwipeLeft.Invoke();
		}

	}

	IEnumerator trance(){
		gameObject.GetComponent<Animator>().SetBool("intrance", true);
		aura.SetActive (true);
		foreach (GameObject obstacleInstance in  GameObject.FindGameObjectsWithTag("obstacleUp")) {
			Vector3 screenPoint = Camera.main.WorldToViewportPoint(obstacleInstance.transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
			if (onScreen) {
				Destroy (obstacleInstance);
			}
		}

		yield return new WaitForSeconds (1.1f);
		aura.SetActive (false);
		gameObject.GetComponent<Animator>().SetBool("intrance", false);
	}

	IEnumerator defence(){
		gameObject.GetComponent<Animator>().SetBool("defence", true);

		foreach (GameObject obstacleInstance in  GameObject.FindGameObjectsWithTag("obstacleDown")) {
			Vector3 screenPoint = Camera.main.WorldToViewportPoint(obstacleInstance.transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
			if (onScreen) {
				Destroy (obstacleInstance);
			}
		}

		yield return new WaitForSeconds (1.5f);
		gameObject.GetComponent<Animator>().SetBool("defence", false);
	}

	IEnumerator rightHit(){
		gameObject.GetComponent<_2dxFX_PlasmaShield> ().enabled = true;
		gameObject.GetComponent<Animator>().SetBool("intrance", true);

		foreach (GameObject obstacleInstance in  GameObject.FindGameObjectsWithTag("obstacleRight")) {
			Vector3 screenPoint = Camera.main.WorldToViewportPoint(obstacleInstance.transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
			if (onScreen) {
				Destroy (obstacleInstance);
			}
		}

		yield return new WaitForSeconds (1.1f);
		gameObject.GetComponent<Animator>().SetBool("intrance", false);
		gameObject.GetComponent<_2dxFX_PlasmaShield> ().enabled = false;
	}


	IEnumerator leftHit(){
		gameObject.GetComponent<_2dxFX_Lightning> ().enabled = true;
		gameObject.GetComponent<Animator>().SetBool("intrance", true);

		foreach (GameObject obstacleInstance in  GameObject.FindGameObjectsWithTag("obstacleLeft")) {
			Vector3 screenPoint = Camera.main.WorldToViewportPoint(obstacleInstance.transform.position);
			bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
			if (onScreen) {
				Destroy (obstacleInstance);
			}
		}

		yield return new WaitForSeconds (1.1f);
		gameObject.GetComponent<_2dxFX_Lightning> ().enabled = false;
		gameObject.GetComponent<Animator>().SetBool("intrance", false);
	}

	IEnumerator takeHit(){
		gameObject.GetComponent<Animator>().SetBool("hited", true);
		yield return new WaitForSeconds (1.5f);
		gameObject.GetComponent<Animator>().SetBool("hited", false);
		Application.LoadLevel (Application.loadedLevel);
	}

	public void swipeUpResponse(){
		StartCoroutine(trance());
		Debug.Log("Up");
	}

	public void swipeDownResponse(){
		StartCoroutine(defence ());
		Debug.Log("Down");
	}

	public void swipeRightResponse(){
		StartCoroutine(rightHit());
		Debug.Log("Right");
	}

	public void swipeLeftResponse(){
		StartCoroutine(leftHit());
		Debug.Log("Left");
	}


}