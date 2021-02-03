using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollowCamera : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    
    // Before start
    void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // After update, it defines the following movement of the camera with the player in the center of the screen
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 posA = new Vector3 (transform.position.x, transform.position.y, -10);
            Vector3 posB = new Vector3 (player.position.x, player.position.y, player.position.z);
            transform.position = Vector3.Lerp(posA, posB, followSpeed * Time.deltaTime);
        }   
    }
}
