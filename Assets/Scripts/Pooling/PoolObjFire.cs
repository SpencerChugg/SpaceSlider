using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolObjFire : MonoBehaviour
{
    public float fireTime = .05f;
    public GameObject fireobject;

    public int pooledAmount = 20;
    public List<GameObject> fireobjects;

    void Start()
    {
        fireobjects = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(fireobject);
            obj.SetActive(false);
            fireobjects.Add(obj);
        }
    }
    public void Fire()
    {
        for (int i = 0; i < fireobjects.Count; i++)
        {
            if (!fireobjects[i].activeInHierarchy)  
            {
                fireobjects[i].transform.position = transform.position;
                fireobjects[i].transform.rotation = transform.rotation;
                fireobjects[i].SetActive(true);
                
                break;
            }
        }
    }
}
