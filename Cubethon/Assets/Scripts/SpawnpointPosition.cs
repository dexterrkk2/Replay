using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointPosition : MonoBehaviour
{
    public Transform player;
    public Vector3 objectOffset;
    public Vector3 newPosition;
    // Update is called once per frame
    void Update()
    {
        newPosition = new Vector3(player.position.x + objectOffset.x, 1, player.position.z + objectOffset.z);
        transform.position = newPosition;
    }
}
