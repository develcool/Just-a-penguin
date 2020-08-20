using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public GameObject VertSosoulka;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Spawn" , 2f ,2f);
    }
    public void Spawn(){
          float y = Random.Range(-2.3f , 2.3f);
             Vector2 vect = new Vector2(y, 6.1f);
             GameObject gm = Instantiate (VertSosoulka , vect , Quaternion.identity) as GameObject;
    }
}
