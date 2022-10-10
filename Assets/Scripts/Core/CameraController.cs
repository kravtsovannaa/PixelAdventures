using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //camera movement
    // [SerializeField] private Transform target; //allows to select the player to follow
    // [SerializeField] private float smoothSpeed = 0.125f;
    // [SerializeField] private Vector3 locationOffset;
    // [SerializeField] private Vector3 rotationOffset;
    private Vector2 velocity;
    [SerializeField] private float smoothTimeY;
    [SerializeField] private float smoothTimeX;
    [SerializeField] private GameObject player;

    // camera zoom
    [SerializeField] private float zoomFactor = 1.0f;
    [SerializeField] private float zoomSpeed = 5.0f;
    private float originalSize = 0f;
    private Camera thisCamera;

    //camera movement restrictions 
    // [SerializeField] private bool bounds;
    // [SerializeField] private Vector3 minCamPos;
    // [SerializeField] private Vector3 maxCamPos;

    void Start()
    {
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }

    private void Update()
    {
        //camera movement
        // Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = smoothedPosition;

        // Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        // Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        // transform.rotation = smoothedrotation;
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
        Debug.Log("1 posX:" + posX);
        Debug.Log("1 posY:" + posY);

        //camera movement restrictions 
        // if(bounds)
        // {
        //     if(transform.position.x < minCamPos.x || transform.position.x > maxCamPos.x)
        //     {
        //         transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x),posY, transform.position.z);
        //         Debug.Log("2 posX:" + posX);
        //         Debug.Log("2 posY:" + posY);
        //     }
        //     else if(transform.position.y < minCamPos.y || transform.position.y > maxCamPos.y)
        //     {
        //         transform.position = new Vector3(posX, Mathf.Clamp(transform.position.x, minCamPos.y, maxCamPos.y), transform.position.z);
        //         Debug.Log("3 posX:" + posX);
        //         Debug.Log("3 posY:" + posY);
        //     }
        // }
        

        // camera zoom
        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }
        
    
    }

    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }
}