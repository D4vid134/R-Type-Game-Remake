using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    [SerializeField] int damage = 1;
    [SerializeField]int bounce = 1;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
        transform.Translate(Vector2.right * Time.deltaTime * 20);
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Structure"))
    //     {
    //         var speed = lastVelocity.magnitude;
    //         var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
    //         rb.velocity = direction * Mathf.Max(speed,0f);
    //     }

    // }

    void OnBecameInvisible() 
    {
         Destroy(this.gameObject);
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

        if (collision.gameObject.CompareTag("Structure"))
        {
            var speed = lastVelocity.magnitude;
            if (bounce ==1)
            {
                transform.Rotate(0f,0f,270f);
                bounce = bounce - 1;
            }
            else
            {
                transform.Rotate(0f,0f,90f);
                bounce = bounce + 1;
            }
        }


    }

}
