using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudScrollScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed;

    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0);
        if (transform.position.x <= -11.0f)
        {
            transform.position = new Vector3(14.6f, 0);
        }
    }
}
