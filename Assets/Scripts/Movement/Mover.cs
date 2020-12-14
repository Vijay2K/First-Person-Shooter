using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS.Control;

namespace FPS.Movement {
    public class Mover : MonoBehaviour {

        #region variableDeclaration

        //Player Movement
        [SerializeField] private CharacterController controller = null;
        [SerializeField] private float moveSpeed = 10f;
        
        private JoystickController joystickController;

        //player jump
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private Transform groundCheck = null;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpingHeight = 3f;

        private Vector3 velocity;
        private bool isGrounded;

        #endregion

        private void Start() {
            joystickController = GetComponent<JoystickController>();
        }

        private void Update() {
            Move();
        }

        private void Move() {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

            if(isGrounded && velocity.y < 0) {
                velocity.y = -2f;
            }

            Vector3 move = transform.right * joystickController.MoveHorizontal() + 
                transform.forward * joystickController.MoveVertical();

            controller.Move(move * moveSpeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

        public void Jump() {
            if (isGrounded) {
                velocity.y = Mathf.Sqrt(jumpingHeight * -2f * gravity);
            }
        }

    }
}
