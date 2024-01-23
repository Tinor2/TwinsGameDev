using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] bool isVertical;
    [Range(0f, 10f)]
    [SerializeField] float basespeed;
    [SerializeField] float thresh1;
    [SerializeField] float thresh2;

    [SerializeField] float speed;
    private Vector3 pos;


    void Start() { speed = basespeed; }

    void Update()
    {
        speed = basespeed * Mathf.Sign(speed) * Time.deltaTime;
        pos = gameObject.transform.position;
        if (isVertical)
        {
            pos.y += speed;
        }
        else
        {
            pos.x += speed;
        }
        gameObject.transform.position = pos;

        if (isVertical)
        {
            if (pos.y >= thresh1) { speed *= -1f; }
            else if (pos.y <= thresh2)
            {
                speed *= -1f;
            }
        }
        else
        {
            if (pos.x >= thresh1)
            {
                speed *= -1f;
            }
            else if (pos.x <= thresh2)
                speed *= -1f;
        }
    }

   public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("s");
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("se");
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("seee");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}

