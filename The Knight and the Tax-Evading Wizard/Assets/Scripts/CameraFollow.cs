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

    [SerializeField] float cameraZoom;

    //Y channeling
    private float cameraYSnippet;
    [SerializeField] float channelThresh;
    [SerializeField] float changeY;
    private float targetY;
    void Start()
    {
        pC = p.GetComponent<PlayerController>();
        cameraComponent = gameObject.GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
      // Y channeling
      changeY = p.transform.position.y - cameraYSnippet;
      if(changeY >= 0){ //if net y movement is positive
        if (changeY >= channelThresh){ 
          targetY = transform.position.y + channelThresh/2;
          cameraYSnippet = transform.position.y;
        }
      }
      if(changeY <= 0){
        if (changeY <= channelThresh *1 ){ //if net y movement is negative
          targetY = transform.position.y - channelThresh/2;
          cameraYSnippet = transform.position.y;
        }
        
      } // Returns targetY value, where the camera should move next
      changeY = 0;
      cameraComponent.orthographicSize = cameraZoom;
      Vector3 movemposition = p.transform.position + offset; 
      float newX = Mathf.SmoothDamp(transform.position.x, movemposition.x, ref zeroV.x, DampingX, speedClamp);
      float newY = Mathf.SmoothDamp(transform.position.y, targetY + offset.y, ref zeroV.y, DampingY, speedClamp);
      transform.position = new Vector3(newX, newY, offset.z);
      if (pC.facingRight){
        offset.x = Mathf.SmoothDamp(offset.x, lookClamp, ref zeroF,lookTime);
      }  
     else{
        offset.x = Mathf.SmoothDamp(offset.x, lookClamp * -1, ref zeroF,lookTime);
      }
    }
}
