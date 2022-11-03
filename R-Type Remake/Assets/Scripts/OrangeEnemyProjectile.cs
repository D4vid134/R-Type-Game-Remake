using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEnemyProjectile : MonoBehaviour
{   
    float speed;
    GameObject player;
    Vector3 currentPlayerPos;
    // [SerializeField] GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
            currentPlayerPos = player.transform.position;
        speed = 20 * Time.deltaTime;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce((currentPlayerPos - transform.position).normalized * 150);
        // this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(1, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
        // transform.position = Vector3.MoveTowards(transform.position, currentPlayerPos, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Structure"))
        {
            Destroy(collision.gameObject);
            // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Player Dies
        }

    }

    void OnBecameInvisible() {
         Destroy(this.gameObject);
     }
}
