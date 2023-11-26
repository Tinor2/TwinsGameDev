using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerController pC;
    private Camera cameraComponent;
    [SerializeField] GameObject p;
    [SerializeField] Vector3 offset;

    [SerializeField] float DampingX;
    [SerializeField] float DampingY;
    [SerializeField] float speedClamp;

    private Vector3 zeroV = Vector3.zero;
    private float zeroF = 0f;
    [SerializeField] float lookClamp;
    [SerializeField] float lookDamp;
    [SerializeField] float lookTime;

    

    //Y channeling
    [SerializeField] float cameraHeight;
    private float boundsA;
    private float boundsB;
    public float tolerance;
    private float tolA;
    private float tolB;
    private float targetY;

    void Start()
    {
        pC = p.GetComponent<PlayerController>();
        cameraComponent = gameObject.GetComponent<Camera>(); 

    }

    // Update is called once per frame
    void Update()
    {
      cameraComponent.orthographicSize = cameraHeight;
      // Y channeling
      float noOffset = transform.position.y - offset.y;
      boundsA = noOffset + cameraHeight;
      boundsB = noOffset - cameraHeight;

      tolA = boundsA - (cameraHeight - tolerance/2);
      tolB = boundsB + (cameraHeight - tolerance/2);

      if(p.transform.position.y > tolA || p.transform.position.y < tolB){
        targetY = p.transform.position.y;
      }

      // Once the player moves to far up, moves the camera back to the player

      Vector3 movemposition = p.transform.position + offset; 
      float newX = Mathf.SmoothDamp(transform.position.x, movemposition.x, ref zeroV.x, DampingX, speedClamp);
      float newY = Mathf.SmoothDamp(transform.position.y, targetY + offset.y, ref zeroV.y, DampingY, speedClamp);
      transform.position = new Vector3(newX, newY, 0 - offset.z);
      if (pC.facingRight){
        offset.x = Mathf.SmoothDamp(offset.x, lookClamp, ref zeroF,lookTime);
      }  
     else{
        offset.x = Mathf.SmoothDamp(offset.x, lookClamp * -1, ref zeroF,lookTime);
      }
    }
}
