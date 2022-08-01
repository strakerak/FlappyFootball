using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //BLOCK 2 ANIMATION STUFF
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // array of sprites
    private int spriteIndex; //keeps track

    // Start is called before the first frame update
    //Beginning stuff, BLOCK 1
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    //BLOCK 2, ANIMATION
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //BLOCK 2 START AFTER ANIMATION
    private void Start()
    {
        //InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
    }

    //BLOCK 1
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Press!");
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime; //deltaTime is just it's own thing, don't worry much about it
        transform.position += direction * Time.deltaTime; //This will be framerate independent, so is consistent on your computer. 
    }

    //BLOCK 2 AFTER START
    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
            spriteIndex = 0;

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    //BLOCK 3
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        if(other.gameObject.tag=="Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
