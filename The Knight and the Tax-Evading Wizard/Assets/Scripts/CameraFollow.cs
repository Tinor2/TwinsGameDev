using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerController pC;
    private Camera cameraComponent;
    [SerializeField] GameObject p;
    [SerializeField] Vector3 offset;

    [SerializeField] float Damping;
    [SerializeField] float speedClamp;

    private Vector3 zeroV = Vector3.zero;
    private float zeroF = 0f;
    [SerializeField] float lookClamp;
    [SerializeField] float lookDamp;
    [SerializeField] float lookTime;

    [SerializeField] float cameraZoom;

    void Start()
    {
        pC = p.GetComponent<PlayerController>();
        cameraComponent = gameObject.GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        cameraComponent.orthographicSize = cameraZoom;
        Vector3 movemposition = p.transform.position + offset; 
        transform.position = Vector3.SmoothDamp(transform.position, movemposition, ref zeroV, Damping, speedClamp);
        if (pC.facingRight){
          offset.x = Mathf.SmoothDamp(offset.x, lookClamp, ref zeroF,lookTime);
        }  
        else{
          offset.x = Mathf.SmoothDamp(offset.x, lookClamp * -1, ref zeroF,lookTime);
        }
    }
}
