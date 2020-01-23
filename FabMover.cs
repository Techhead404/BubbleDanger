using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabMover : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody;
    public float fabShift; 
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector3(speed, 0, 0);
        rigidBody.transform.position = Vector2.left ;
    }

    


}
