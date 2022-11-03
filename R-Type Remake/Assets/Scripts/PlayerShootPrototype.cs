using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootPrototype : ShootPrototype
{   
    public Rigidbody2D normalBullet;
    public Rigidbody2D oneChargeBullet;
    public Rigidbody2D twoChargeBullet;
    public Rigidbody2D threeChargeBullet;
    public Rigidbody2D maxChargeBullet;
    public float power = 0f;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            {   
                power =  power + Time.deltaTime*1;
            }
        
            if (Input.GetKeyUp(KeyCode.Space))
            {   
                if (power > 1.2)
                {
                    Shoot(this.gameObject, maxChargeBullet);
                } 
                else if (power > 0.9)
                {
                    Shoot(this.gameObject, threeChargeBullet);
                }
                else if (power > 0.6)
                {
                    Shoot(this.gameObject, twoChargeBullet);
                }
                else if (power > 0.3)
                {
                    Shoot(this.gameObject, oneChargeBullet);
                }
                else
                {
                    Shoot(this.gameObject, normalBullet);
                }

                power = 0;
            }
    }

    public override void Shoot(GameObject Source, Rigidbody2D Bullet)
    {
        Rigidbody2D playerProjectile = Instantiate(Bullet, new Vector3(Source.transform.position.x, Source.transform.position.y, Source.transform.position.z), Source.transform.rotation) as Rigidbody2D;
        playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
    }
}
