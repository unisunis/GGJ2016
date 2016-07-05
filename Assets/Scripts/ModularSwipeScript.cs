using System.Collections;
using System;
using System.Reflection;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ModularSwipeScript : MonoBehaviour, IEventSystemHandler{

	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;

	[SerializeField]
	private UnityEvent m_onSwipeLeft = new UnityEvent();
	[SerializeField]
	private UnityEvent m_onSwipeRight = new UnityEvent();
	[SerializeField]
	private UnityEvent m_onSwipeUp = new UnityEvent();
	[SerializeField]
	private UnityEvent m_onSwipeDown = new UnityEvent();

	// Update is called once per frame
	void Update () {

	#if UNITY_ANDROID
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

	#elif UNITY_EDITOR || UNITY_EDITOR_OSX
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

	#endif

	}

}