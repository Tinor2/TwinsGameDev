using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;
    public NewControls controls;
    [HideInInspector] public Vector2 moveInput;
    private void Awake(){
        if(instance = null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // else{
        //     Debug.Log("fds");
        //     Destroy(gameObject);
        // }
        controls = new NewControls();
        controls.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }
    private void OnEnable(){
        controls.Enable();
    }
    private void OnDisable(){

        controls.Disable();
    }
}
