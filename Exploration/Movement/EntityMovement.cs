using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exploration
{
    namespace Movement
    {
        [RequireComponent(typeof(Rigidbody2D))]
        [RequireComponent(typeof(Animator))]
        [RequireComponent(typeof(FootstepManager))]
        public class EntityMovement : MonoBehaviour
        {
            //public members
            public Vector2 movementDirection = Vector2.zero;

            //private, serialized fields
            [SerializeField]
            float movementSpeed = 5f;
            [SerializeField]
            float runSpeed = 9f;

            //private fields
            bool running = false;

            Rigidbody2D rb2D;
            Animator animator;

            //public methods
            public void DoMoving(Vector2 direction, bool setAnimationWalking)
            {
                movementDirection = direction;
                
                
                animator.SetFloat("Horizontal", movementDirection.x);
                animator.SetFloat("Vertical", movementDirection.y);
            }

            public void StopMoving()
            {
                running = false;
                movementDirection = Vector2.zero;

                animator.SetFloat("Horizontal", 0f);
                animator.SetFloat("Vertical", 0f);
            }

            public void ToggleRunning()
            {
                SetRunning(!running);
            }

            public void SetRunning(bool setRunning)
            {
                running = setRunning;
                animator.SetBool("Running", setRunning);
            }

            //Unity Methods
            void Start()
            {
                rb2D = GetComponent<Rigidbody2D>();
                animator = GetComponent<Animator>();
            }

            void FixedUpdate()
            {
                float movingSpeed = running ? runSpeed : movementSpeed;

                rb2D.MovePosition((Vector2)transform.position + (movementDirection * movingSpeed * Time.fixedDeltaTime));
            }
        }
    }
}