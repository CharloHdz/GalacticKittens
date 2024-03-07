using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMov : NetworkBehaviour
{
    public float px, py, speed = 5f;
    public Rigidbody2D rb;

    //GameObjects
    public GameObject Bomba;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        px = Input.GetAxis("Horizontal");
        py = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(px * speed, py * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisparoServerRpc();
        }
    }

    [ServerRpc]
    void DisparoServerRpc()
    {
        NetworkObjectSpawner.SpawnNewNetworkObject(Bomba, transform.position, transform.rotation);
    }
}
