using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrappScript : MonoBehaviour {

    public GameObject Spike1, Spike2, Spike3;

	// Use this for initialization
	void Start () {
        Spike1.SetActive(false);
        Spike2.SetActive(false);
        Spike3.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ellen")
        {
            Spike1.SetActive(true);
            Spike2.SetActive(true);
            Spike3.SetActive(true);
        }
    }
}
