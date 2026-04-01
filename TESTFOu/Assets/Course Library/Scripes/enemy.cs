using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    public float speed=5f;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        player=FindObjectOfType<PlayerControl>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null) return;


        Vector3 playerDir=(player.transform.position-transform.position).normalized;

        rb.AddForce(playerDir * speed);

        Debug.Log(transform.position.y);
        if (transform.position.y < -5)
        {
           
            Destroy(gameObject);
       }
    }
}
