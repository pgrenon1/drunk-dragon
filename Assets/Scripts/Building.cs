using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public float Speed;
    public float Health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.left * Speed;
        if (transform.position.x < - 24)
        {
            Destroy(gameObject);
        }
	}
}