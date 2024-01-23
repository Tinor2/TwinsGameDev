using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;
    [HideInInspector] public NewControls controls;
    [HideInInspector] public Vector2 moveInput;
    private void Awake(){
        if(instance = null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        controls = new NewControls();
    }
    private void OnEnable(){
        controls.Enable();
    }
    private void OnDisable(){
        controls.Disable();
    }
}
