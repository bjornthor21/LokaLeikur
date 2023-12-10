using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // public breytir fyrir hra�a, �tt , og hversu lengi l��ur � milli a� hann breytir um �tt
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
 
    public AudioClip playerHitClip;
    public AudioClip botHitClip;

    public ParticleSystem SmokeEffect;

    // Private breytur fyrir Rigidbody2D, timer og �tt
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

        // ef hann er settur til a� hreyfa sig upp og ni�ur
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        // annars fer hann h�gri til vinstri
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
        // athugar hvort �vinur snertir ruby
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            // ef svo er �� er l�f players breytt og hlj�� spila�
            player.ChangeHealth(-1);
            player.PlaySound(playerHitClip);
        }
    }

    public void shot()
    {
        // ey�ir �vini ef hann er skotinn
        Destroy(gameObject);
    }
}
