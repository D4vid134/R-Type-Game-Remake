using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D enemyProjectile;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(1f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer =  timer - Time.deltaTime*1;


        if (timer <= 0) 
        {
            enemyProjectile = Instantiate(enemyProjectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            timer = Random.Range(3f, 7.0f);
        }

    }
}
