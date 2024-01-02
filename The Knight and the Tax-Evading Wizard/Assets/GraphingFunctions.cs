using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphingFunctions : MonoBehaviour
{
    [SerializeField] int Resolution;
    [SerializeField] LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr.positionCount = Resolution;
        for (int i = 0; i < Resolution; i++)
        {
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
