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
    public Rigidbody2D rocket;
    public Rigidbody2D laser;
    public Rigidbody2D laser2;
    public Rigidbody2D snake;
    public Rigidbody2D snake2;
    public bool hasLaser = false;
    public bool hasSnake = false;
    public bool hasRocket = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            hasSnake = true;
            // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("PowerUpLaser"))
        {
            hasLaser = true;
            // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            {   
                power =  power + Time.deltaTime*1;
            }
        
            if (Input.GetKeyUp(KeyCode.Space))
            {   
                ShootPowerUps(this.gameObject);
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
        playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 600);
    }

    public void ShootPowerUps(GameObject Source)
    {   
        if(this.hasRocket)
        {
            Rigidbody2D playerProjectile = Instantiate(rocket, new Vector3(Source.transform.position.x, 
            Source.transform.position.y, Source.transform.position.z), Source.transform.rotation) as Rigidbody2D;
            playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 600);
        }
        if(this.hasLaser)
        {   
            float Angle = 45;   
            Quaternion Rotation = Quaternion.Euler( 0, 0, Angle);
            Rigidbody2D playerProjectile = Instantiate(laser, new Vector3(Source.transform.position.x, 
            Source.transform.position.y, Source.transform.position.z), Rotation) as Rigidbody2D;
            playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 200);

            float Angle1 = 315;   
            Quaternion Rotation1 = Quaternion.Euler( 0, 0, Angle1);
            Rigidbody2D playerProjectile1 = Instantiate(laser2, new Vector3(Source.transform.position.x, 
            Source.transform.position.y, Source.transform.position.z), Rotation1) as Rigidbody2D;
            playerProjectile1.GetComponent<Rigidbody2D>().AddForce(transform.right * 200);
        }
        if(this.hasSnake)
        {
            Rigidbody2D playerProjectile = Instantiate(snake, new Vector3(Source.transform.position.x, 
            Source.transform.position.y, Source.transform.position.z), Source.transform.rotation) as Rigidbody2D;
            playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 600);
            playerProjectile = Instantiate(snake2, new Vector3(Source.transform.position.x, 
            Source.transform.position.y, Source.transform.position.z), Source.transform.rotation) as Rigidbody2D;
            playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 600);
            
        }
        
    }
}
