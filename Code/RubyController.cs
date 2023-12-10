using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // public breytur fyrir hra�a ruby, heildar l�f, skot, stig, hlj�� og hopp kraft.
    public float speed = 3.0f;
    public int maxHealth = 5;
    public GameObject projectilePrefab;
    public static int points;
    public AudioClip shootClip;
    public float jumpForce;

    // groundcheck
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    // n�verandi l�f
    public int health { get { return currentHealth; } }
    int currentHealth;

    // pr�vat breytur fyrir rb, input, animation, �ttir og audiosource
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    AudioSource audioSource;

    void Start()
    {
        // setur breytur
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        isGrounded = true;
        points = 0;
    }

    // Update is called once per frame.
    void Update()
    {
        // f�r input breytur
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        // b�r til vector �r �eim breytum
        Vector2 move = new Vector2(horizontal, vertical);

        // breytir look direction.
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        // breytir animation.
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        // hopp logic.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.x, jumpForce));
        }

        // skot logic.
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
            this.PlaySound(shootClip);
        }
    }

    void FixedUpdate()
    {
        // athugar hvort ruby er � j�r�inni.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // hreyfir ruby.
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    // Spilar h�j��.
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // breytir l�fi.
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    // sk�tur skoti.
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        animator.SetTrigger("Launch");
    }
}
