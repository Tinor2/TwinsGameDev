using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TarodevController;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("References")]
    private PlayerController pC;
    private Camera cameraComponent;
    [SerializeField] GameObject p;
    [SerializeField] Vector3 offset;
    [Header("Camera Damp Values")]
    [SerializeField] float DampingX;
    [SerializeField] float DampingY;
    
    [Header("Lookahead")]
    private Vector3 zeroV = Vector3.zero;
    private float zeroF = 0f;
    [SerializeField] float lookClamp;
    [SerializeField] float lookDamp;
    [SerializeField] float lookTime;

    

    [Header("Y Channeling")]
    [SerializeField] float cameraHeight;
    private float boundsA;
    private float boundsB;
    public float tolerance;
    private float tolA;
    private float tolB;
    private float targetY;

    [Header("Camera Tweening")]
    [Range(-20f,20f)]
    [SerializeField] float baseSpeedClamp;
    [Range(-20f,20f)]
    [SerializeField] float slope;
    [Range(-20f,20f)]
    [SerializeField] float tweenXOffset;
    [Range(-20f,20f)]
    [SerializeField] float tweenYOffset;
    [Range(-20f,20f)]
    [SerializeField] float distanceTillClamp;
    [Range(-20f,20f)]
    public float startSpeed;
    

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
      
      boundsA = transform.position.y + cameraHeight; 
      boundsB = transform.position.y - cameraHeight; 

      tolA = boundsA - (cameraHeight - tolerance/2) + offset.y; //Update the bounds to include the decreased y pos due to offset
      tolB = boundsB + (cameraHeight - tolerance/2) - offset.y; // ^^                              increased                  ^^

      if(p.transform.position.y > tolA || p.transform.position.y < tolB){
        targetY = p.transform.position.y;
      }
      // Once the player moves to far up, moves the camera back to the player
      float distanceFromTarget = transform.position.y - targetY;
      float speedClamp = Mathf.Pow(Mathf.Pow(baseSpeedClamp,-1f)+Mathf.Pow(slope,Mathf.Abs(distanceFromTarget+tweenXOffset)),-1f)+ tweenYOffset;
      /*  Tweening function above writteen in laymans terms: 1/((b^-1)+c^(|x|+d))
          Function written in LATEX: \frac{1}{b^{-1}+c^{\left|x\right|+d}}+a
          where
          a: Shifts the function vertically (tweenYOffset)
          b: Controls the max speed (baseSpeedClamp)
          c: Changes how fast the function levels off, or the slope of the function (slope)
          d: Shifts the function horizontally. Practically, it does the same thing as c, except it also changes the starting height


      */


      Vector3 movemposition = p.transform.position + offset; 
      float newX = Mathf.SmoothDamp(transform.position.x, movemposition.x, ref zeroV.x, DampingX, baseSpeedClamp);
      float newY = Mathf.SmoothDamp(transform.position.y, targetY + offset.y, ref zeroV.y, DampingY, baseSpeedClamp);
      transform.position = new Vector3(newX,newY,-offset.z);
      if (pC.facingRight){
        offset.x = Mathf.SmoothDamp(offset.x, lookClamp, ref zeroF,lookTime);
      }  
      else{
        offset.x = Mathf.SmoothDamp(offset.x, lookClamp * -1, ref zeroF,lookTime);
      }
    }
}
