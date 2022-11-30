using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    [SerializeField] int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 20);
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
            Destroy(this.gameObject);
        }

    }

    void OnBecameInvisible() {
         Destroy(this.gameObject);
     }
}
