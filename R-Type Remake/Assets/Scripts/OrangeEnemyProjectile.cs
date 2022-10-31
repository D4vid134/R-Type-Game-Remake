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
        speed = 2 * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPlayerPos, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Player Dies
        }

    }
}