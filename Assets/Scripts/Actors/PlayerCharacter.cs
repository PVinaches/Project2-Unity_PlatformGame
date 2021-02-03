using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public LayerMask groundCollision;
    public float movementSpeed = 7000f;
    public float jumpSpeed = 12000f;
    public float groundThresh = 0.2f;
    public float life = 70f;
    public int score;
    public HealthBar healthBar;
    public UIScore uIScore;
    public AudioClip hitClip;

    private SpriteRenderer _sr;
    private Animator _anim;
    private CapsuleCollider2D _capsule;
    private Rigidbody2D _rb;
    
    private float _vertical;
    private float _horizontal;
    private bool _grounded;
    private AudioSource _audio;

    [HideInInspector]
    public bool flip = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _capsule = GetComponent<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        score = 0;
        healthBar.SetMaxHealth(life);
        uIScore.UpdateText(score);
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        // To flip the character left or right
        if (_horizontal < 0 && !flip)
        {
            _sr.flipX = true;
            flip = true;
        }
        else if (_horizontal > 0 && flip)
        {
            _sr.flipX = false;
            flip = false;
        }
    }

    void FixedUpdate()
    {
        // To run
        if (_horizontal != 0)
        {
            // To move the player
            _rb.AddForce(Vector2.right * _horizontal * movementSpeed * Time.deltaTime, ForceMode2D.Force);

            // How to set the properties of the animator
            _anim.SetFloat("Speed", Mathf.Abs(_horizontal));
            _anim.SetFloat("HorizontalVelocity", Mathf.Abs(_rb.velocity.x));

            // Running sound
            _audio.UnPause();
        }
        else
        {
            // Stop running sound while not running
            _audio.Pause();
        }

        // To jump
        _grounded = Physics2D.Raycast(transform.position, -Vector3.up, groundThresh, groundCollision);

        if ((_vertical > 0) && _grounded)
        {
            _audio.Pause();
            _anim.SetBool("Jumping", true);
            _rb.AddForce(Vector3.up * jumpSpeed * Time.deltaTime, ForceMode2D.Force);
        }
        else if (_grounded)
        {
            _anim.SetBool("Jumping", false);
        }
    }

    // Score counting
    public void RaisePoints(int points)
    {
        score += points;
        uIScore.UpdateText(score);
        
        if (score > 59)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame(score);
        }         
    }

    // Damage to the player
    public void TakeDamage(float damage)
    {
        // Sound
        GetComponent<AudioSource>().PlayOneShot(hitClip);
        
        life -= damage;
        
        // Update healthBar
        healthBar.SetHealth(life);

        // Death condition
        if (damage > life)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame(score);
        }   
    }
}
