using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.left * Speed;

        if (transform.position.x < -24)
        {
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
}
