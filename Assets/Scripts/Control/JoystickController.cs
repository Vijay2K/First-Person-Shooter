using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Control {
    public class JoystickController : MonoBehaviour {

        [SerializeField] private Joystick joystick = null;

        private float moveHorizontal;
        private float moveVertical;

        public float MoveHorizontal() {
            return moveHorizontal;
        }

        public float MoveVertical() {
            return moveVertical;
        }

        private void Update() {
            moveHorizontal = joystick.Horizontal;
            moveVertical = joystick.Vertical;
        }
    }
}
