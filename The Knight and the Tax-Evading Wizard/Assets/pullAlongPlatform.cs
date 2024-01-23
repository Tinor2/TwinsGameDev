using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullAlongPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
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
