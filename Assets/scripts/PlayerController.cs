using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool can_jump;
    public Animator animator;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.GetAxisRaw("Horizontal"));

        // Movimiento
        if (Input.GetKey("left")) {
            gameObject.transform.localScale = new Vector3(-1F, 1F, 1F);
            gameObject.transform.Translate(-75f * Time.deltaTime, 0, 0);
        } else if (Input.GetKey("right")) {
            gameObject.transform.localScale = new Vector3(1F, 1F, 1F);
            gameObject.transform.Translate(75f * Time.deltaTime, 0, 0);
        }

        // Animacion para correr
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("Running", true);
        } else {
            animator.SetBool("Running", false);
        }

        // Salto
        if (Input.GetKeyDown("space") && can_jump) {
            can_jump = false;
            body.AddForce(new Vector2(0, 375F), ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "ground") {
            can_jump = true;
            animator.SetBool("Jumping", false);
        }
    }
}