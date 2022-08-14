using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
      

         if (other.gameObject.tag == "Life Pwr")
        {
            other.transform.GetComponent<BoxCollider2D>().enabled = false;
        }
    

        //Life Line
        else if (other.gameObject.tag == "LifeLine Pwr")
        {
            other.transform.GetComponent<BoxCollider2D>().enabled=false;
        }
        

        //Double
        else if (other.gameObject.tag == "Double Pwr")
        {
        other.transform.GetComponent<BoxCollider2D>().enabled=false;
        }
        
    }
}
