using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command
{
    public class playerCollision : MonoBehaviour
    {
        private PlayerMovement playerMvmnt;
        // Start is called before the first frame update
        public void Start()
        {
            playerMvmnt = FindObjectOfType<PlayerMovement>();
        }
        void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.collider.tag == "Obstacle")
            {
                playerMvmnt.enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
            else if (collisionInfo.collider.tag == "Ground")
            {
                playerMvmnt.jumpCount = 0;
            }
        }
    }
}
