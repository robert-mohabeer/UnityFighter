using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    //smoothspeed can be any value between 0 and 1
    public float smoothSpeed = 0.125f; //default speed 0.125f 
    public Vector3 offset; //adds offset in unity properties

    //updates later or somthing to make it follow player smoothly with no jitter/snapping
    //potential alternative using FixedUpdate() instead of LateUpdate()
    void LateUpdate()
    {
        //marks player location with offset
        Vector3 desiredPosition = target.position + offset;
        //smooths the camera follow
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); 
        //sets camera location
        transform.position = smoothedPosition;
    }
}
