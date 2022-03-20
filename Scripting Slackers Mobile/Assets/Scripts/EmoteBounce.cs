using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteBounce : MonoBehaviour
{
 

    public new Rigidbody2D rigidbody { get; private set; }

    public float speed = 500f;

        private void Awake() 
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = Random.Range(-1f,1f);

        this.rigidbody.AddForce(force.normalized * this.speed);
    }
}
