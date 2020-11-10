using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UI;
using UnityEngine;

namespace Movement
{
    public class MoveCharacter : MonoBehaviour
    {
        // Start is called before the first frame update
        public CharacterController control;  
        public float speed = 6f;
        public float jumpHeight = 3f;
        public float characterGravity = -20f;
        
        public Transform checkFloor;
        public float sphereRay = 0.4f;
        public LayerMask floorMask;
        public bool onTheFloor;
        Vector3 speedFall; 

        void Start()
        {
            control = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("MoveCharacter Update");
            onTheFloor = Physics.CheckSphere(checkFloor.position, sphereRay,floorMask);

            if(onTheFloor && speedFall.y < 0)
            {
                speedFall.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * x + transform.forward * z).normalized;

            control.Move(move * speed * Time.deltaTime);

            if(Input.GetButtonDown("Jump") && onTheFloor)
            {
                speedFall.y = Mathf.Sqrt(jumpHeight * -2f * characterGravity);
                Debug.Log("Jump and onTheFloor");
            }

            speedFall.y += characterGravity * Time.deltaTime;

            control.Move(speedFall * Time.deltaTime);

            Debug.Log("speedFall.y: " + speedFall.y);
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(checkFloor.position, sphereRay);
        }
        
        }
    }
