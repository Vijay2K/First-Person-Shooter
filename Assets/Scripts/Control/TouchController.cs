using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Control {
    public class TouchController : MonoBehaviour {

        [SerializeField] private float cameraSenetivity = 10f;
        [SerializeField] private Transform cameraTransform = null;

        private int rightFingerId;
        private Vector2 lookInput;
        private float cameraPitch;
        private float halfScreenWidth;


        private void Start() {
            rightFingerId = -1;        
            halfScreenWidth = Screen.width / 2;
        }


        private void Update() {
            GetTouchInput();

            if(rightFingerId != -1) {
                LookAround();
            }
        }

        private void LookAround() {
            cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);

            cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
            transform.Rotate(transform.up, lookInput.x);
        }

        private void GetTouchInput() {
            for(int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.GetTouch(i);

                switch (touch.phase) {
                    case TouchPhase.Began:
                        if(touch.position.x > halfScreenWidth && rightFingerId == -1) {
                            rightFingerId = touch.fingerId;
                            Debug.Log("Right Screen Touch works");
                        }
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        if(touch.fingerId == rightFingerId) {
                            rightFingerId = -1;
                            Debug.Log("right screen touch Stopped");
                        }
                        break;
                    case TouchPhase.Moved:
                        if(touch.fingerId == rightFingerId) {
                            lookInput = touch.deltaPosition * cameraSenetivity * Time.deltaTime;
                        }
                        break;
                    case TouchPhase.Stationary:
                        if(touch.fingerId == rightFingerId) {
                            lookInput = Vector2.zero;
                        }
                        break;
                }
            }
        }

    }
}
