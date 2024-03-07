using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class LifeTime : MonoBehaviour
{
    public float lifeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            
        }
    }

    [ServerRpc]
    void DestroyServerRpc()
    {
        //NetworkObjectDespawner.DestroyServerObject(this.gameObject);
    }
}
