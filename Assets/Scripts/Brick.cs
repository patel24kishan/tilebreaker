using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{

    [SerializeField] private Transform _Explode;
  //  public bool isParent = false;

    
    private void Start()
    {
        _Explode.gameObject.SetActive(true);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="brick")
        {
            other.gameObject.transform.parent.GetComponent<AudioSource>().Play();
            other.gameObject.SetActive(false);


         
            if (other.transform.parent!=null)
            {
                other.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
                if (other.transform.parent.tag=="Main Tile")
                {
                    GameManager.instance.UpdateScore();
                    Instantiate(_Explode, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject);
                   // Destroy(_Explode.gameObject, 1.0f);
                }
            }
           

         
        }

       
    }

}
