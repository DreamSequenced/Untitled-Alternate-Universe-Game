using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private PlayerSoundManager soundManager;

    [SerializeField]
    [Range(0.05f, 20f)]
    private float moveSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float walkingSoundInterval;
    private float walkingSoundCounter;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private void Start()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        soundManager = GetComponent<PlayerSoundManager>();
        
        walkingSoundCounter = walkingSoundInterval;
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        Move(moveX);
        SetSpriteAnimation(moveX);
        RestrictToBounds();
    }

    private void Move(float moveX)
    {
        rigidbody2D.velocity = new Vector3(moveX, rigidbody2D.velocity.y, 0f);

        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }

        if(moveX != 0f)
        {
            if(CheckPlayStepSound())
            {
                soundManager.PlayWalkingSound();
            }
        }
    }

    private bool CheckPlayStepSound()
    {
        if (walkingSoundCounter <= 0f)
        {
            walkingSoundCounter = walkingSoundInterval;
            return true;
        }
        else
        {
            walkingSoundCounter -= Time.deltaTime;
            return false;
        }
    }

    private void RestrictToBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    private void SetSpriteAnimation(float moveX)
    {
        animator.SetFloat("moveX", moveX);

        if (moveX >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

            // Ensure player canvas isn't flipped
            float childScaleX = transform.GetChild(0).localScale.x;
            float childScaleY = transform.GetChild(0).localScale.y;
            transform.GetChild(0).localScale = new Vector3(Mathf.Abs(childScaleX), Mathf.Abs(childScaleY), 1f);
        }
        else if (moveX <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

            // Ensure player canvas isn't flipped
            float childScaleX = transform.GetChild(0).localScale.x;
            float childScaleY = transform.GetChild(0).localScale.y;
            transform.GetChild(0).localScale = new Vector3(-Mathf.Abs(childScaleX), Mathf.Abs(childScaleY), 1f);
        }
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(.5f, .5f, 0f);
        topRightLimit = topRight + new Vector3(-.5f, -.5f, 0f);
    }
}
