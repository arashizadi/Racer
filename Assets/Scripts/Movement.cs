using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public KeyCode rightKey;
    public KeyCode leftKey;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        
    }    
    protected virtual void FixedUpdate()
    {
        
    }
}
