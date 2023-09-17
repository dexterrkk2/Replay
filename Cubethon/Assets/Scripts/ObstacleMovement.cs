using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command {
    public class ObstacleMovement : MonoBehaviour
    {
        public Rigidbody rb;
        public float force = 8000;
        public Invoker invoke;
        public List<float> startTimes;
        public Vector3 offset;
        public void Start()
        {
            invoke = gameObject.AddComponent<Invoker>();
        }
        // Update is called once per frame
        void Update()
        { 
           Forward();
        }
        public void ResetPosition(Transform spawnPoint)
        {
            gameObject.SetActive(false);
            transform.position = new Vector3(spawnPoint.position.x + offset.x, spawnPoint.position.y + offset.y, spawnPoint.position.z + offset.z);
            rb.velocity = new Vector3(0,0,0);
        }
        public void Forward()
        {
            rb.AddForce(-Vector3.forward * force);
        }
    }
}
