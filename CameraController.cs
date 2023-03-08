using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; //Transform component of player

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.tag == "Player")
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        
    }
}
