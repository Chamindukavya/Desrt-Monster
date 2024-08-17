using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float maxX, minX;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player == null){
            return;
        }

        tempPos = transform.position;
        tempPos.x = player.position.x;
        

        if (tempPos.x < -5.5f){
            tempPos.x = -5.5f;
        }
        if (tempPos.x> 22.53f){
            tempPos.x = 22.53f;
        }
        transform.position = tempPos;
    }
}
