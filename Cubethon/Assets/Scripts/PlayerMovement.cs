using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command
{
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody rb;
        public float forwardForce;
        public float sidewaysForce;
        public float jumpForce;
        public bool moveRight;
        public bool moveLeft;
        public Vector3 startPosition;
        public int jumpCount;
        // Update is called once per frame
        private void Update()
        {
            if (rb.position.y < -1f)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
        public void Jump()
        {
            if (jumpCount<=2)
            {
                Vector3 jumpPosition = new Vector3(transform.position.x, transform.position.y + jumpForce, transform.position.z);
                rb.MovePosition(jumpPosition);
                jumpCount++;
            }
        }
        public void TurnLeft()
        {
            Vector3 movePosition = new Vector3(transform.position.x-sidewaysForce, transform.position.y, transform.position.z);
            rb.MovePosition(movePosition);
        }
        public void TurnRight()
        {
            Vector3 movePositionx = new Vector3(transform.position.x+sidewaysForce, transform.position.y, transform.position.z);
            rb.MovePosition(movePositionx);
        }
        public void ResetPosition()
        {
            rb.velocity = new Vector3(0,0,0);
            transform.position = startPosition;
        }
    }
}