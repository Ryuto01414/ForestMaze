using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public int force = 1;
    Rigidbody myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            myRB.AddForce(new Vector3(force, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            myRB.AddForce(new Vector3(-force, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triger:" + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision:" + collision.gameObject.name);
    }
}
