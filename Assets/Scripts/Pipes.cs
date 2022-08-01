using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Start is called before the first frame update
    // BLOCK 1
    public float speed = 5f;

    //BLOCK 2
    private float leftEdge;

    //BLOCK 2
    private void Start()
    {
        //Converting screen to worldspace.
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    //BLOCK 1
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x<leftEdge)
        {
            Destroy(gameObject);
        }
    }


}
