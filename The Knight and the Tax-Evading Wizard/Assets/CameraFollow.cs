using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerController pC;
    [SerializeField] GameObject p;
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset;
    
    void Start()
    {
        pC = p.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
          Vector3 movemposition = target.transform.position - offset; 
          
    }
}
