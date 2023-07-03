using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

//This script causes the bullet tom move
public class BulletMove : MonoBehaviour
{
    //defining variables
    //Magnitude of speed of bullet movement
    [Tooltip("!!!!the SPEED variable MUST BE INPUTTED AS NEGATIVE!!!!")]
    public float speed;
    //Velocity (includes direction) of bullet movement
    private float fspeed;

    public bool bulletflip;
    
    



    void Update()
    {
        //Checking what direction to face
        if (gameObject.transform.rotation == Quaternion.Euler(0,180,0)) {
            fspeed = Mathf.Abs(speed);
        }
        if (gameObject.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            fspeed = speed;
        }
        //Updating transform of the bullet by a certain value (determined by the float speed)
        transform.position += new Vector3(fspeed, 0, 0);
    }
    //Checking colison
    
}
