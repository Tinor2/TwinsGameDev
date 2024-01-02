using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GraphingFunctions : MonoBehaviour
{
    [SerializeField] int resolution;
    [SerializeField] int pointSpacing;
    [SerializeField] LineRenderer lr;

    public Vector3 focalPoint;
    public float focalWidth;

    // Start is called before the first frame update
    void Start()
    {
        lr.positionCount = resolution;

        for (int i = 0; i < resolution; i++)
        {
            float nextPos = focalPoint.x - focalWidth + pointSpacing*i;
            lr.SetPosition(i, new Vector3(nextPos, gameObject.transform.position.y, gameObject.transform.position.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
