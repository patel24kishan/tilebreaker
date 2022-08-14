using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour

{
    private float dirX;

    public float Speed=50f;

    //public GameManager _Gm;
    [SerializeField] private PowerUp _PuL,_PuLL,_PuD;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject _BottomWall;
    
    private bool isright,isclicked;
    public int Power_index;
    void Start()
    {
       
    }

    void Update()
    {

        if (isright)
        {
            if (isclicked)
            {
                if (player.position.x < 9.4)
                {
                   // print(player.position.x);
                    player.Translate(Vector3.right * Speed * Time.deltaTime);
                }
                
            }
        }
        else
        {
            if (isclicked)
            {
                if (player.position.x > -9.4)
                {
                    player.Translate(Vector3.left * Speed * Time.deltaTime);
                }
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            onKeyDownRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            onKeyDownLeft();
        }

    }

    //Power Up
    /* public void OnCollisionEnter2D(Collision2D other)
     {
         //Life
         if (other.gameObject.tag=="Life Pwr")
         {
            _Gm.Life();
            other.gameObject.SetActive(false);

            StartCoroutine("SpawnDelay");


         }

         //Life Line
         else if (other.gameObject.tag == "LifeLine Pwr")
         {
             _Gm.LifeLine();
            // _Gm.Life();
           //  _BottomWall.SetActive(false);
             other.gameObject.SetActive(false);
             Power_index = 1;
             StartCoroutine("SpawnDelay");
            // _PuLL.Spawn();
         }

         //Double
         else if (other.gameObject.tag == "Double Pwr")
         {
             _Gm.LifeLine();
           //  _Gm.Life();
             other.gameObject.SetActive(false);
             Power_index = 2;
             StartCoroutine(SpawnDelay());
            // _PuD.Spawn();
         }
     }*/

    public void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<RawImage>().enabled = false;
        //Life
        if (other.gameObject.tag == "Life Pwr")
        {
            GameManager.instance.Life();
           
            Destroy(other.gameObject,1);

        }

        //Life Line
        else if (other.gameObject.tag == "LifeLine Pwr")
        {
            
            GameManager.instance.LifeLine();
           
            Destroy(other.gameObject,1);
        }

        //Double
        else if (other.gameObject.tag == "Double Pwr")
        {
            GameManager.instance.Double();
            Destroy(other.gameObject,1);
        }
    }

    public void onKeyDownLeft()
    {
        isclicked = true;
        isright = false;
        
    }

    public void onKeyDownRight()
    {
        isclicked = true;
        isright = true;
       
    }

    public void onKeyUpLeft_Right()
    {
        isclicked = false;
    }

}