using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform CharacterTransform; 
    Vector3 range;

    private void Awake()
    {
        range = transform.position - CharacterTransform.position;
    }
    
	void FixedUpdate () {
        transform.position = new Vector3(range.x + CharacterTransform.position.x, transform.position.y, range.z + CharacterTransform.position.z);
	}
}
