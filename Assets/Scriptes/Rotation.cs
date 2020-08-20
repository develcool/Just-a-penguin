using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
 void Start(){

 }
 void FixedUpdate(){
     transform.Rotate(0f, 0f, 9f);
 }
}
