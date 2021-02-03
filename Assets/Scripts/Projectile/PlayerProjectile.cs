using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damage = 10;
    public float speed = 6f;
    public float rate = 0.5f;

    private SpriteRenderer _sr;
    
    private float _y;

    [HideInInspector]
    public GameObject shooter;
    
    // Start is called before the first frame update
    void Start()
    {   
        _sr = GetComponent<SpriteRenderer>();

        // Verify the player's position to flip the projectile left or right
        if (FindObjectOfType<PlayerCharacter>().flip)
        {
            _sr.flipX = false;
            _y = -1;
        }
        else if (!FindObjectOfType<PlayerCharacter>().flip)
        {
            _sr.flipX = true;
            _y = 1;
        }
    }

    // Update is called once per frame
    // Movement of the projectile
    void Update()
    {
        transform.Translate(Vector3.right * _y * Time.deltaTime * speed, Space.World);
        Destroy(gameObject, 1f);
    }

    // Hitting an enemy
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy en = hitInfo.GetComponent<Enemy>();
        EnemyBeetle eb = hitInfo.GetComponent<EnemyBeetle>();
        if (en != null)
            en.TakeDamageEnemy(damage);
        else if (eb != null)
            eb.TakeDamageBeetle(damage);
        
        Destroy(gameObject);
    }
}
