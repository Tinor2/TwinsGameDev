using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformReaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("jklda"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Elevator")
        {
            Debug.Log("PlatformCollide");
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("JFKJSFDKL");
            collision.gameObject.transform.SetParent(null);
        }
    }
}
