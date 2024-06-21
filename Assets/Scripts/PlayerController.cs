using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using powerup;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movimiento")]
        public float moveSpeed;
        public float jumpForce;

        public CharacterController controller;
        private Vector3 moveDirection;

        public float gravityScale;

        [Header("Boosters")]
        public float jumpBoost;
        public float speedBoost;
        public float BoostTime;
        bool SpeedBooster;
        bool JumpBooster;
        public Booster boosters;

        [Header("Animaciones")]
        public Animator animator;
        Vector3 Playermov;

        void Start()
        {
           
        }


        void Update()
        {
            Movement();
        }

        void Movement()
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
            if (controller.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            controller.Move(moveDirection * Time.deltaTime);

            //animacion
            Playermov = moveDirection.normalized; //.normalized para normalizar el num del vector
            animator.SetFloat("Jumping", Playermov.y);
            //Debug.Log(Playermov.z + "and " + moveDirection.z);
            animator.SetFloat("Velocity", Playermov.sqrMagnitude);
        }

        public void JumpBoost()
        {
            jumpForce = jumpForce + jumpBoost;
        }

        public void SpeedBoost()
        {
            moveSpeed = moveSpeed + speedBoost;
        }

        
        void EndBoostJump()
        {
            //SpeedBooster = false;
            //JumpBooster = false;
            jumpForce = jumpForce - jumpBoost;
            //moveSpeed = moveSpeed - speedBoost;
            Debug.Log("Terminó el Boost, velocidad de salto: " + jumpForce);
        }

        void EndBoostSpeed()
        {
            moveSpeed = moveSpeed - speedBoost;
            Debug.Log("Terminó el Boost, velocidad: " + moveSpeed);
        }
    }
}
