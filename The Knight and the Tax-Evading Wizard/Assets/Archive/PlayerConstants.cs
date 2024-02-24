using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstants : MonoBehaviour
{
    public GameObject FirePoint;

    public bool pC_PlayerFlip;
    private Follow firePointFollow;
    // Start is called before the first frame update
    void Start()
    {
        firePointFollow = FirePoint.GetComponent<Follow>();

    }

    // Update is called once per frame
    void Update()
    {
        pC_PlayerFlip = firePointFollow.isFlip;
        
    }
}
