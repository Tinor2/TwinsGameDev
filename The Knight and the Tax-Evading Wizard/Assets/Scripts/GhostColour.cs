using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GhostColour : MonoBehaviour
{
    public GameObject player;
    private Charactar charactar;
    public SpriteRenderer sp;
    public Color knightColor;
    public Color wizardColor;
    // Start is called before the first frame update
    void Start()
    {
        charactar = player.GetComponent<Charactar>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!charactar.character) //Player is now knight
        {
            sp.color = knightColor;
        }
        else
        { //Player is now wizard
            sp.color = wizardColor;
        }
    }
}
