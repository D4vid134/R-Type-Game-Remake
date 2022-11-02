using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Rigidbody2D NormalBullet;
    float movespeed = 5f;
    float speedlimiter = .7f;
    float inputHorizontal;
    float inputVertical;
    private float timer = 0f;
    public float delayAmount;
    [SerializeField]
    public float power = 0f;
    [SerializeField]
    public int projectilSpeed = 0;
   
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
            if (power < 0.25)
            {
                Rigidbody2D playerProjectile = Instantiate(NormalBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
                playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectilSpeed);
            } else {
                Rigidbody2D playerProjectile = Instantiate(NormalBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
                playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
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
}
