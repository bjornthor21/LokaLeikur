using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // public breytir fyrir hraða, átt , og hversu lengi líður á milli að hann breytir um átt
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
 
    public AudioClip playerHitClip;
    public AudioClip botHitClip;

    public ParticleSystem SmokeEffect;

    // Private breytur fyrir Rigidbody2D, timer og átt
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    // Animator
    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // breytir timer.
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        // hreyfi logic.
        Vector2 position = rigidbody2D.position;

        // ef hann er settur til að hreyfa sig upp og niður
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        // annars fer hann hægri til vinstri
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // athugar hvort óvinur snertir ruby
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            // ef svo er þá er líf players breytt og hljóð spilað
            player.ChangeHealth(-1);
            player.PlaySound(playerHitClip);
        }
    }

    public void shot()
    {
        // eyðir óvini ef hann er skotinn
        Destroy(gameObject);
    }
}
