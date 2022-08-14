using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public static BallMovement BM;
    private Rigidbody2D rb;
    [SerializeField] private GameObject bottomWall;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Shoot;
    [SerializeField] private GameObject _Can;
    [SerializeField] private bool bottomUp;
    [SerializeField] private bool isPlay;
    [SerializeField] private bool isDouble;
    [SerializeField] private bool temp;

    [SerializeField] private AudioClip _ShootClip, _ballhitClip;
    
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        BM = this;
        rb = GetComponent<Rigidbody2D>();
       // _Gm= GameObject.Find("Game_Controller");
        bottomWall= GameObject.Find("BottomWall");
        player= GameObject.Find("Player");
        Shoot= GameObject.Find("Shoot_Button");
        _Can = this.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        _ballhitClip = this.gameObject.GetComponent<AudioSource>().clip;

        //bottomUp = true;
        isPlay = false;

    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.velocity.magnitude;
        if (isDouble==true)
        {
            
            if (temp==false)
            {
                isPlay = true;
                rb.AddForce(Vector2.up * 50);
                temp = true;
            }

            if (rb.velocity.magnitude < 8 && rb.velocity.magnitude != 0)
            {
                rb.AddForce(Vector2.up * 30f);
            }

            if (transform.localPosition.y < -5.4)
            {
                       // isPlay = false;
                       Destroy(rb.gameObject);
                       isDouble = false;
            }
                
        }
        else
        {
            if ( rb.velocity.magnitude < 8 && rb.velocity.magnitude != 0)
            {
                rb.AddForce(Vector2.up * 30f);
            }

            
                if (isPlay)
                {
                   
                        if (transform.localPosition.y < -5.4)
                        {
                            
                        if (GameObject.Find("Ball (Double)(Clone)")==null)
                        {
                            isPlay = false;
                            rb.gameObject.SetActive(false);
                            ResetPosition();
                        }

                        }
                  
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="ball" || other.gameObject.tag == "wall")
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }


    public void ResetPosition()
    {
        rb.gameObject.SetActive(true);
        //_Gm.UpdateLives();
        GameManager.instance.UpdateLives();
        rb.velocity=Vector2.zero;
        
        transform.parent = player.transform;
        transform.localPosition = new Vector3(0, 1.34f, 0);

        if  (GameManager.instance.LivesCount == 0)
        {
            GameManager.instance.GameOver();                                //GAME OVER
        }
        Shoot.SetActive(true);
        isPlay = false;
    }

    public void shootButton()
    {
         isPlay = true;

        rb.AddForce(Vector2.up * 75f);
        Shoot.GetComponent<AudioSource>().PlayOneShot(_ShootClip);
        StartCoroutine(Shootdelay());
            // Shoot.SetActive(false);
        transform.parent = _Can.transform;
    }

    IEnumerator Shootdelay()
    {
        yield return new WaitForSeconds(0.3f);
        Shoot.SetActive(false);
    }

}
