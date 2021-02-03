using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeetle : MonoBehaviour
{
    public float bHealth = 50;
    public float bSpeed = 4f;
    public float bHitDamage = 5f;
    public float bDistFollow = 10f;
    public int bPointsWorth = 20;

    public Transform _player;
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sr;
    private CircleCollider2D _circle;
    private bool _dealtDamage = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            if ((_player.position.x - _rb.position.x) > 0)
                _sr.flipX = true;
            else
            {
                _sr.flipX = false;
            }

            // Small IA so the enemy follows the player once the player is nearby
            if (Vector2.Distance(_player.position, _rb.position) < bDistFollow)
            {
                _anim.SetBool("Following", true);
                Vector2 target = new Vector2(_player.position.x, _player.position.y);
                Vector2 newPos = Vector2.MoveTowards(_rb.position, target, bSpeed * Time.deltaTime);
                _rb.MovePosition(newPos);
            }
            else
            {
                _anim.SetBool("Following", false);
            }
        }     
    }

    // Hitting the player
    IEnumerator OnTriggerStay2D(Collider2D hitInfo)
    {
        PlayerCharacter player = hitInfo.GetComponent<PlayerCharacter>();
        if (_dealtDamage)
            yield return null;
        
        if (player != null && !_dealtDamage)
        {
            _dealtDamage = true;
            yield return new WaitForSeconds(0.5f);
            player.TakeDamage(bHitDamage);
            _dealtDamage = false;    
        }
    }
    
    // Killing the enemy
    public void TakeDamageBeetle(float damage)
    {
        if (damage > bHealth)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>().RaisePoints(bPointsWorth);
        }

        bHealth -= damage;
    }
}
