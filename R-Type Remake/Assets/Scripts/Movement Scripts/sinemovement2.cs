using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinemovement2 : MonoBehaviour
{
    [SerializeField]
    float amp = 1f;
    [SerializeField]
    float frequency = 1f;


    float sinCenterY;

    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * amp;
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }
}
