using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zigzagmovment : MonoBehaviour
{
    [SerializeField]
    float diagspeed = 1f;

    [SerializeField]
    float bound = 5f;

    bool movingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > bound)
        {
            movingUp = false;
        }
        if (transform.position.y < -bound)
        {
            movingUp = true;
        }

        if (movingUp == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * diagspeed);
        }
        if (movingUp == false) {
            transform.Translate(Vector3.down * Time.deltaTime * diagspeed);
        }

    }
}
