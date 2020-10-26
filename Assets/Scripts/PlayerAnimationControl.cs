using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerSprite;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private NinjaController.NinjaController nc;

    private bool movingRight = false;

    public float idleThreshold = 0.25f;
    public float jumpThreshold = 0.5f;

    public float rayStart = 0.45f;
    public float rayLength = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        if (playerSprite == null)
        {
            playerSprite = GetComponentInChildren<SpriteRenderer>();
        }
        if (playerAnimator == null)
        {
            playerAnimator = GetComponentInChildren<Animator>();
        }
        if (nc == null)
        {
            nc = GetComponent<NinjaController.NinjaController>();
        }
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
        UpdateAnimationParameters();
    }

    private void UpdateAnimationParameters()
    {
        //Debug.Log($"Idle? {Mathf.Abs(rb.velocity.x) < idleThreshold}");
        playerAnimator.SetBool("Idling", Mathf.Abs(nc.Velocity.x) < idleThreshold);

        //Debug.Log($"Jump Up? {rb.velocity.y > jumpThreshold}");
        playerAnimator.SetBool("MoveUpwards", nc.Velocity.y > jumpThreshold);


        //Debug.DrawRay(this.transform.position + (Vector3)Vector2.down * rayStart, Vector2.down * (rayStart + rayLength));
        // RaycastHit2D hit = Physics2D.Raycast(this.transform.position + (Vector3)Vector2.down * rayStart, Vector2.down, rayLength);
        //Debug.Log(hit.transform);
        playerAnimator.SetBool("Grounded", nc.IsOnGround);//hit);
    }

}
