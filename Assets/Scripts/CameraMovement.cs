using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform targetToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(targetToFollow.position.x, -4.68f, 4.44f), Mathf.Clamp(targetToFollow.position.y, -2.12f, 2.15f), transform.position.z);
    }
}
