// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.Pool;

// public class BulletChilding : MonoBehaviour
// {
    
//     public GameObject ObjectPool; //Make a gameobject where I acsess the objectPooling script
//     private ObjectPooling objectPooling; //objectPooling script to be used

//     public GameObject Player; //player Gameobject used to access the player combat script
//     private PlayerCombat playerCombatScript; // Player combat script variable

//     private Follow follow;
//     [SerializeField] GameObject prefabinlist;
//     public GameObject currentPrefabInUse;


//     void Awake()
//     {
//         objectPooling = ObjectPool.GetComponent<ObjectPooling>();
//         playerCombatScript = Player.GetComponent<PlayerCombat>();    
//         follow = gameObject.GetComponent<Follow>();
//     }
//     void Update()
//     {
//         for (int i = 0; i < objectPooling.poolSize; i++)
//         {
//             prefabinlist = objectPooling.objectPoollist[i];
//             if (!prefabinlist.activeSelf)
//             {
//                 currentPrefabInUse = prefabinlist;
//                 if (follow.isFlip)
//                 {
//                     currentPrefabInUse.transform.rotation = Quaternion.Euler(0, 0, 0);
//                 }
//                 else
//                 {
//                     currentPrefabInUse.transform.rotation = Quaternion.Euler(0, 180, 0);
//                 }
//                 while (playerCombatScript.attacking)
//                 {
//                     break;
//                 }
//             }
//             else {
//                 currentPrefabInUse = objectPooling.objectPoollist[i];
//             }
//         }
        
        
//         }
//     }

