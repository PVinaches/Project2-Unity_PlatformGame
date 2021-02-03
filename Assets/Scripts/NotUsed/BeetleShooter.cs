using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleShooter : MonoBehaviour
{
    public BeetleBall ball;
    public Transform  attackStart;

    private int _counter;
    private bool _started = false;

    void Start()
    {
        _counter = 1;
    }
    
    void Update()
    {
        if (_counter == 50)
        {
            StartCoroutine(Attack());
        }
        else
        {
            _counter++;
        }
    }

    public IEnumerator Attack()
    {
        float p = ball.rateBall;
        if (_started)
            yield return null;
        if (!_started)
        {
            _started = true;
            yield return new WaitForSecondsRealtime(p);

            Vector3 positionBall = new Vector3(attackStart.position.x, attackStart.position.y, attackStart.position.z);  
            BeetleBall bProj = Instantiate(ball, positionBall, Quaternion.identity);

            _started = false;
        }
        
    }
}
