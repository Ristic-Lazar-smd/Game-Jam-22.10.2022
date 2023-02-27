using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    //public Animator animator;
    float horizontal;
    float vertical;


    public float runSpeed;
    Animator animator;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isMovingNoArm", false);
        animator.SetBool("isMoving", true);
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0)
        {
            animator.SetBool("isMovingNoArm", false);
            sound.Stop();
        }

        if (horizontal > 0)
        {
            animator.SetBool("isMovingNoArm", true);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            sound.Play();
        }

        if (horizontal < 0)
        {
            animator.SetBool("isMovingNoArm", true);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            sound.Play();
        }

        if (vertical != 0)
        {
            animator.SetBool("isMovingNoArm", true);
            sound.Play();
        }



        //if (horizontal == 0 && vertical == 0)
        //{
        //    animator.SetBool("stand", true);
        //}
        //else {
        //    animator.SetBool("stand", false);
        //}
        ////
        //if (horizontal < 0 && vertical > 0)
        //{
        //    animator.SetBool("ul", true);
        //}
        //else
        //{
        //    animator.SetBool("ul", false);
        //}
        ////
        //if (horizontal > 0 && vertical > 0)
        //{
        //    animator.SetBool("ur", true);
        //}
        //else
        //{
        //    animator.SetBool("ur", false);
        //}
        ////
        //if (horizontal > 0 && vertical < 0)
        //{
        //    animator.SetBool("dr", true);
        //}
        //else
        //{
        //    animator.SetBool("dr", false);
        //}
        ////
        //if (horizontal < 0 && vertical < 0)
        //{
        //    animator.SetBool("dl", true);
        //}
        //else
        //{
        //    animator.SetBool("dl", false);
        //}



        //animator.SetFloat("dir_h", horizontal);
        //animator.SetFloat("dir_v", vertical);


        // initially, the temporary vector should equal the player's position
        Vector3 clampedPosition = transform.position;
        // Now we can manipulte it to clamp the y element (i x)
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5.51f, 5.15f);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -12.55f, 12.78f);
        // re-assigning the transform's position will clamp it
        transform.position = clampedPosition;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed).normalized*runSpeed;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}