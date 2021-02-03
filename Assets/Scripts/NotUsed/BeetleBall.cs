using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleBall : MonoBehaviour
{
    public int damageBall = 5;
    public float rateBall = 3f;
    public float speedBall = 6f;

    private SpriteRenderer _beBall;
    private CircleCollider2D _cc;
    private Transform _movements;
    /* private int _newCounter; */

    /* [HideInInspector] */
    public GameObject beetleShooter;
    
    // Start is called before the first frame update
    void Start()
    {
        _beBall = GetComponent<SpriteRenderer>();
        _cc = GetComponent<CircleCollider2D>();
        _movements = GetComponent<Transform>();
    }

    // Update is called once per frame
    // Movement of the enemy ball
    void Update()
    {
        _movements.Translate(Vector3.right * Time.deltaTime * speedBall, Space.World);

        Destroy(gameObject, 500f);
    }

    // Hitting an player
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerCharacter pl = hitInfo.GetComponent<PlayerCharacter>();
        if (pl != null)
        {
            pl.TakeDamage(damageBall);
            Destroy(gameObject);
        }    
    }
}
