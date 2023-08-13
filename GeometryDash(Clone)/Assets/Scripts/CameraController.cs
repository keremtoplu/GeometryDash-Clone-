using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraOffSet;
    [SerializeField]
    private float smoothTime=.25f;
    [SerializeField]
    private Transform targetTransform;
    private Vector3 velocity=Vector3.zero;
    void Start()
    {
        cameraOffSet=new Vector3(transform.position.x-targetTransform.position.x,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() 
    {
        Vector3 targetPos=targetTransform.position+cameraOffSet;
        targetPos.y=transform.position.y;
        targetPos.z=transform.position.z;
        transform.position=Vector3.SmoothDamp(transform.position,targetPos,ref velocity,smoothTime);
    }
}
