using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerSprite;
    //[SerializeField]
    //private Rigidbody2D rb;

    private bool movingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playerSprite == null)
        {
            playerSprite = GetComponentInChildren<SpriteRenderer>();
        }
        //if (rb == null)
        //{
        //    rb = GetComponent<Rigidbody2D>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Horizontal") > 0 && !movingRight)
        {
            playerSprite.flipX = false;
            movingRight = true;
        }
        else if (Input.GetAxis("Horizontal") < 0 && movingRight)
        {
            playerSprite.flipX = true;
            movingRight = false;
        }
    }
}
