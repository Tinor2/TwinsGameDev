using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private float moveInput;
    public UserInput userInput;
    public GameObject inputManager;
    // Start is called before the first frame update
    void Start()
    {
        userInput = inputManager.GetComponent<UserInput>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moveInput);
    }
}
