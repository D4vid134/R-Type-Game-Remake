using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    float movespeed = 5f;
    float constantspeed = 1f;
    float speedlimiter = .7f;
    float inputHorizontal;
    float inputVertical;
    private float timer = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

	private void FixedUpdate()
	{
        if (inputHorizontal != 0 || inputVertical != 0)
        {

            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedlimiter;
                inputVertical *= speedlimiter;
            }

            rb.velocity = new Vector2((inputHorizontal * movespeed) + constantspeed, inputVertical * movespeed);
        }
        else
        {
            rb.velocity = new Vector2(constantspeed, 0f);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Structure") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

    }


}
