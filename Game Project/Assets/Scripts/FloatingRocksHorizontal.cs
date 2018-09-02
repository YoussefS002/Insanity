using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRocksHorizontal : MonoBehaviour {
    public float xMin, xMax;
    public int speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        MoveHorizontal();
    }

    void MoveHorizontal()
    {
        if (transform.position.x <= xMin)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        if (transform.position.x >= xMax)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
    }
}
