using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    public float speed = 1f;
    public float velocity;
    public float links;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        velocity = transform.position.x + velocity;
        links = transform.position.x - links;
    }
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < links) {
            transform.eulerAngles = rotation - new Vector3(0,180,0);
        }

        if (transform.position.x > velocity) {
                transform.eulerAngles = rotation ;
        }
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if(currentHealth <= 0){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
        Debug.Log("Enemy Died!");
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
         if (collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}
