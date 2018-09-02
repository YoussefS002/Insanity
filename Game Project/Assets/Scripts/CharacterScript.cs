using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour {

    public int speed, jumpForce;
    private bool grounded;
    bool isDead;
    bool abovePad;
    public GameObject PressurePadDark1, PressurePadLight1;
    public GameObject PressurePadDark2, PressurePadLight2;
    public GameObject PressurePadDark3, PressurePadLight3;
    public GameObject Elen;
    public GameObject replayTextGameObject;

    void Start () {
        isDead = false;
        SetPressurePadToDark1();
        SetPressurePadToDark2();
        SetPressurePadToDark3();
        replayTextGameObject.SetActive(false);
	}
    void Update()
    {
        Replay();
    }
    void FixedUpdate () {
        Move();
        Jump();
        PressurePadBehaviour1();
        PressurePadBehaviour2();
        PressurePadBehaviour3();
        if (transform.position.y <= -7)
        {
            isDead = true;
        }
        if (isDead == true)
        {
            replayTextGameObject.SetActive(true);
            Invoke("Die", 0.1f);
        }
    }

    void Move()
    {
            if (Input.GetKey(KeyCode.RightArrow)&& !isDead)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.localScale = new Vector3(1f, 1f, 1);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && !isDead)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                transform.localScale = new Vector3(-1f, 1f, 1);
            }
            if (((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && (grounded || abovePad))&& !isDead)            {
                GetComponent<Animator>().SetBool("isWalking", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("isWalking", false);
            }  
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow) && grounded && !isDead)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        }
    }
    void Die()
    {
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 90);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    void Replay()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }  
    }
    void PressurePadBehaviour1()
    {
        InvokeRepeating("SetPressurePadToDark1", 0.5f, 3f);
        InvokeRepeating("SetPressurePadToLight1",2f, 3f);
    }
    void SetPressurePadToDark1()
    {
        PressurePadDark1.SetActive(true);
        PressurePadLight1.SetActive(false);
    }
    void SetPressurePadToLight1()
    {
        PressurePadDark1.SetActive(false);
        PressurePadLight1.SetActive(true);
    }

    void PressurePadBehaviour2()
    {
        InvokeRepeating("SetPressurePadToDark2", 1.5f, 3f);
        InvokeRepeating("SetPressurePadToLight2", 3f, 3f);
    }
    void SetPressurePadToDark2()
    {
        PressurePadDark2.SetActive(true);
        PressurePadLight2.SetActive(false);

    }
    void SetPressurePadToLight2()
    {
        PressurePadDark2.SetActive(false);
        PressurePadLight2.SetActive(true);
    }

    void PressurePadBehaviour3()
    {
        InvokeRepeating("SetPressurePadToDark3", 2.5f, 3f);
        InvokeRepeating("SetPressurePadToLight3", 4f, 3f);
    }
    void SetPressurePadToDark3()
    {
        PressurePadDark3.SetActive(true);
        PressurePadLight3.SetActive(false);
    }
    void SetPressurePadToLight3()
    {
        PressurePadDark3.SetActive(false);
        PressurePadLight3.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpForce = 7;
        }
        if (collision.gameObject.tag == "Pad")
        {
            abovePad = true;
        }
        if (collision.gameObject.name == "Bouncer")
        {
            grounded = true;
            jumpForce = 11;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        }
        if (collision.gameObject.tag == "Spike")
        {
            isDead = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
