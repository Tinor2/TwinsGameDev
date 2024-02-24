using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField] float basespeed;
    [SerializeField] float thresh;

    [SerializeField] float speed;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        speed = basespeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = (basespeed / 100) * Mathf.Sign(speed);
        pos = gameObject.transform.position;
        pos.y += speed;
        gameObject.transform.position = pos;
        if(Mathf.Abs(pos.y) >= thresh)
        {

            speed *= -1f;
        }

    }
}
