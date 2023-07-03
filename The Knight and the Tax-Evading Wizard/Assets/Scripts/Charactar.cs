using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactar : MonoBehaviour
{
    [SerializeField, Tooltip("True is Knight, False is Wizard")]
    public bool character;
    [SerializeField] SpriteRenderer sp;

    [SerializeField] Color knightColor;
    [SerializeField] Color wizardColor;
    // Start is called before the first frame update
    void Start()
    {
        character = true;
        //true = knight
        //false = wizard
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x")) {
            character = !character;
        }
        

        if (character == true) //Player is now knight
        {
            sp.color = knightColor;
        }
        else { //Player is now wizard
            sp.color = wizardColor;
        }
    }
}
