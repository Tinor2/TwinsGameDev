using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class Follow : MonoBehaviour
{
    //Accessing player controller
    private PlayerController playerController;
    //Accessing player Gameobject 
    public GameObject player;
    //Do we want this object to flip around the player?
    public bool FlipEnable;
    //Is the object flipped at the momment or not i.e is the object in the default position?
    public bool isFlip;
    //If the FlipEnable == true, then how large or small should th offset be?
    public float xoffset;
    

    [SerializeField] Vector3 offset; //the offset the follower will be at
    [SerializeField] Transform target; //the position of the target
    public float Damping; //Determines the "delay" of the movement

    [SerializeField] Vector3 velocity = Vector3.zero;
    void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        Vector3 movemposition = target.position - offset; //Setting a vector3 variable to the desired location of the follower
        transform.position = Vector3.SmoothDamp(transform.position, movemposition, ref velocity, Damping);
        if (FlipEnable) {
            if (playerController.facingRight == true)
            {
                //positive
                isFlip = false;
                offset = new Vector3(offset.x = xoffset, offset.y, offset.z);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            if (playerController.facingRight == false) {
                //negative
                isFlip = true;
                offset = new Vector3(offset.x = -xoffset, offset.y, offset.z);
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }
    } 
}
