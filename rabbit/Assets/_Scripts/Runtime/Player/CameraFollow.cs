
using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform followTransform;
    public BoxCollider2D mapBounds;
    public Camera mainCam;

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthsize;
    private float cameraRatio;
    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;
    private float _horzExtent;
    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
        _horzExtent = camOrthsize * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + _horzExtent, xMax - _horzExtent);
        smoothPos= Vector3.Lerp(mainCam.transform.position, new Vector3(camX,camY,mainCam.transform.position.z), smoothSpeed);
        mainCam.transform.position = smoothPos;



    }
}
