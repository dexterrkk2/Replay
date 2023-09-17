using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command
{
    public class followPlayer : MonoBehaviour
    {
        private PlayerMovement player;
        public Vector3 cameraOffset;
        public void Start()
        {
            player = FindObjectOfType<PlayerMovement>();
        }
        // Update is called once per frame
        void Update()
        {
            transform.position = player.transform.position + cameraOffset;
        }
    }
}
