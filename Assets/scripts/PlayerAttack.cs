using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float time_btw_attack;
    public float start_time_before_attack;

    public Transform attack_position;
    public LayerMask is_enemy;
    public float attack_range;
    public int damage;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.Play("player_attacking");
            Collider2D[] damaged_enemies = Physics2D.OverlapCircleAll(attack_position.position, attack_range, is_enemy);
            for (int i = 0; i < damaged_enemies.Length; i++)
            {
                damaged_enemies[i].GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        /*if (time_btw_attack <= 0) {
            if (Input.GetKey(KeyCode.Z)) {
                animator.Play("player_attacking");
                Collider2D[] damaged_enemies = Physics2D.OverlapCircleAll(attack_position.position, attack_range, is_enemy);
                for (int i = 0; i < damaged_enemies.Length; i++) {
                    damaged_enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            time_btw_attack = start_time_before_attack;
        } else {
            time_btw_attack -= Time.deltaTime;
        }*/
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack_position.position, attack_range);
    }
}
