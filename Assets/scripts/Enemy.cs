using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            animator.Play("skeleton_destroyed");
            // Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        animator.Play("skeleton_hit");
        Debug.Log("DAMAGE TAKEN! CURRENT HEALTH: " + health);
    }
}