using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDataObject", menuName = "PlayerValues")]
public class PlayerConstants : ScriptableObject
{
    public GameObject FirePoint;

    public bool PlayerFlip;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Follow firePointFollow = FirePoint.GetComponent<Follow>();
        PlayerFlip = firePointFollow.isFlip;
    }
}
