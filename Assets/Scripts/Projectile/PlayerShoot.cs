using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShoot : MonoBehaviour
{
    public PlayerProjectile projectile;
    public Transform firePoint;
    public GameObject shoot;
    
    private Animator _anim;
    private bool _shooted = false;
    private float _n;
    private AudioSource _audio;
    
    // Start is called before the first frame update
    void Start()
    {
        _audio = shoot.GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        _n = Convert.ToSingle(-2);
    }

    // Update is called once per frame
    void Update()
    {
        // Condition to start shooting
        if (Input.GetKey(KeyCode.Space) && !_anim.GetBool("Jumping"))
        {
            _anim.SetBool("Shooting", true);
            StartCoroutine(Shoot());
        }
        else
        {
            _anim.SetBool("Shooting", false);
        }
    }

    public IEnumerator Shoot()
    {
        float t = projectile.rate;
        _audio.Play();
        if (_shooted)
            yield return null;
        if (!_shooted)
        {
            _shooted = true;

            // Start audio
            _audio.Play();
            yield return new WaitForSeconds(t);
            

            // The projectile will be instantiated at the coordinates of the fire point (right) or displaced to the left of the player
            if (FindObjectOfType<PlayerCharacter>().flip)
            {
                Vector3 position1 = new Vector3((firePoint.position.x + _n), firePoint.position.y, firePoint.position.z);  
                PlayerProjectile proj = Instantiate(projectile, position1, Quaternion.identity);  
            }
                
            else if (!FindObjectOfType<PlayerCharacter>().flip)
            {
                PlayerProjectile proj = Instantiate(projectile, firePoint.position, Quaternion.identity);
            }

            _shooted = false;
        }
    }
}
