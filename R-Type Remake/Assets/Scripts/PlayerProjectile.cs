using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    [SerializeField] int damage = 1;

    //void Fire1()
    //{
    //    Rigidbody2D playerProjectile = Instantiate(playerProjectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;

    //    playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);

    //    coolDown = Time.time + attackSpeed;
    //}

    //void Fire2()
    //{
    //    Rigidbody2D playerProjectile = Instantiate(playerProjectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;

    //    playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);

    //    coolDown = Time.time + attackSpeed;
    //}

    //void Fire3()
    //{
    //    Rigidbody2D playerProjectile = Instantiate(playerProjectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;

    //    playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);

    //    coolDown = Time.time + attackSpeed;
    //}

    //void Fire4()
    //{
    //    Rigidbody2D playerProjectile = Instantiate(playerProjectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;

    //    playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);

    //    coolDown = Time.time + attackSpeed;
    //}

    //void FireMax()
    //{
    //    Rigidbody2D playerProjectile = Instantiate(playerProjectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;

    //    playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);

    //    coolDown = Time.time + attackSpeed;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
            health.takeDamage(damage);
            // Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            if (damage == 1)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
