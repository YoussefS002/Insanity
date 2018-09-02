using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFinishUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ellen")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 0.5f;
        }
    }
}
