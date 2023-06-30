using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{


    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();

        }
    }
    private void Die()
    {
        //Disable Movement
        rb.bodyType = RigidbodyType2D.Static;

        sr.color = Color.red;
        //Play Death Animation

        anim.SetTrigger("Death");

        //Remove Sprite
        //Done
        //Wait for a Bit
        
    }
    private void RestartLevel()
    {
        //Restart Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
