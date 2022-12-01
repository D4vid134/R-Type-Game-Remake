using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<EnemyShootPrototype>().enabled = false;
        this.GetComponent<moveleft>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
       {
           if (other.gameObject.tag == "FrontBorder")
           {
               this.GetComponent<EnemyShootPrototype>().enabled = true;
               this.GetComponent<moveleft>().enabled = true;
           }
       }
}