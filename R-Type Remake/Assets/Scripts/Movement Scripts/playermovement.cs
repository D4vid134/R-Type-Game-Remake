using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Rigidbody2D normalBullet;
    public Rigidbody2D oneChargeBullet;
    public Rigidbody2D twoChargeBullet;
    public Rigidbody2D threeChargeBullet;
    public Rigidbody2D maxChargeBullet;

    float movespeed = 5f;
    float speedlimiter = .7f;
    float inputHorizontal;
    float inputVertical;
    private float timer = 0f;
    public float power = 0f;
    [SerializeField]
    public int projectileSpeed = 0;
   
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

        if (Input.GetKey(KeyCode.Space))
        {   
            power =  power + Time.deltaTime*1;
        }
       
        if (Input.GetKeyUp(KeyCode.Space))
        {   
            if (power > 1.2)
            {
                Rigidbody2D playerProjectile = Instantiate(maxChargeBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
                playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
            } 
            else if (power > 0.9)
            {
                Rigidbody2D playerProjectile = Instantiate(threeChargeBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
                playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
            }
            else if (power > 0.6)
            {
                Rigidbody2D playerProjectile = Instantiate(twoChargeBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
                playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
            }
            else if (power > 0.3)
            {
                Rigidbody2D playerProjectile = Instantiate(oneChargeBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
                playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
            }
            else
            {
                Rigidbody2D playerProjectile = Instantiate(normalBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
                playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
            }

            power = 0;
        }
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

            rb.velocity = new Vector2(inputHorizontal * movespeed, inputVertical * movespeed);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
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
