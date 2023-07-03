using UnityEngine;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
{
    public GameObject prefabToPool;
    public int poolSize;
    public List<GameObject> objectPoollist;


    void Awake()
    {
        // Create a new list to hold the pooled objects
        objectPoollist = new List<GameObject>();

        // Instantiate the objects and add them to the pool
        for (int i = 0; i < poolSize; i++)
        {
            
            GameObject newObject = Instantiate(prefabToPool);
            newObject.SetActive(false);
            objectPoollist.Add(newObject);
            
        }
    }

    public GameObject GetObjectFromPool()
    {
        // Search for an inactive object in the pool and return it
        for (int i = 0; i < objectPoollist.Count; i++){
            if (!objectPoollist[i].activeInHierarchy){
                objectPoollist[i].SetActive(true);
                return objectPoollist[i];
            }
        }

        
        return null;
    }
}