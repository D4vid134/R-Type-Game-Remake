using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootPrototype : ShootPrototype
{
    [SerializeField]
    Rigidbody2D enemyProjectile;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(1f, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer =  timer - Time.deltaTime*1;

        if (timer <= 0) 
        {
            Shoot(this.gameObject, enemyProjectile);
            timer = Random.Range(3f, 8.0f);
        }

    }

    public override void Shoot(GameObject Source, Rigidbody2D Bullet)
    {
        Rigidbody2D playerProjectile = Instantiate(Bullet, new Vector3(Source.transform.position.x, 
        Source.transform.position.y, Source.transform.position.z), Source.transform.rotation) as Rigidbody2D;
    }
}
