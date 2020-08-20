using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public float i;
    public float speed;
    new public Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(-5f, -8f);
        i = Random.Range(8f,15f);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        
     rigidbody2D.velocity = new Vector2(speed , rigidbody2D.velocity.y);
     
     transform.Rotate(0f, 0f,i);
    
    }
    
}
