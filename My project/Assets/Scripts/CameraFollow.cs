using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
   
    //LateUpdate happens after Update, good for cameras
    private void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z - 10),
            Time.deltaTime * 100);

    }
}
