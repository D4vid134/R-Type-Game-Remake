using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootPrototype : MonoBehaviour
{
    public virtual void Shoot(GameObject Source, Rigidbody2D Bullet)
    {
        Rigidbody2D playerProjectile = Instantiate(Bullet, new Vector3(Source.transform.position.x, 
        Source.transform.position.y, Source.transform.position.z), Source.transform.rotation) as Rigidbody2D;
        playerProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
    }

}
