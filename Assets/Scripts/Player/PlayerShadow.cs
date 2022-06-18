using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    public PlayerMovement player;

    public Vector3 positionChange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0 , player.rigibody.position.z - player.z + positionChange.z);
    }
}
