using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class BulletChilding : MonoBehaviour
{
    public GameObject ObjectPool;
    public ObjectPooling objectPooling;

    public GameObject player;
    [SerializeField] PlayerCombat playerCombatScript;

    public Follow follow;

    private GameObject prefabinlist;
    public GameObject currentPrefabInUse;



    void Awake()
    {
        objectPooling = ObjectPool.GetComponent<ObjectPooling>();
        PlayerCombat playerCombatScript = player.GetComponent<PlayerCombat>();    
        follow = gameObject.GetComponent<Follow>();
    }
    void Update()
    {
        for (int i = 0; i < objectPooling.poolSize; i++)
        {
            prefabinlist = objectPooling.objectPoollist[i];
            if (!prefabinlist.activeSelf)
            {
                currentPrefabInUse = prefabinlist;
                if (follow.isFlip)
                {
    
                    currentPrefabInUse.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    currentPrefabInUse.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                while (playerCombatScript.attacking)
                {
                    break;
                }
            }
            else {
                currentPrefabInUse = objectPooling.objectPoollist[i];
            }
        }
        
        
        }
    }

