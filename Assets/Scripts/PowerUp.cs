using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject rb;

    //public Rigidbody2D _gb;

    [SerializeField] private int time;
    private AudioClip clip;

    // public GameObject[] _SpawnPrefab;
    private float x;

    private float y;

    [SerializeField] private int SpawnValue, temp;


    // Start is called before the first frame update
    void Start()
    {
        clip = GetComponent<AudioSource>().clip;

    }



    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y < -2.7f)
        {
            transform.GetComponent<BoxCollider2D>().enabled = true;

        }


        if (transform.localPosition.y < -6)
        {
            Destroy(this.gameObject);
            // this.gameObject.SetActive(false);
            // Spawn();
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //gameObject.GetComponent<AudioSource>().Play();
        //Life
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("enter");
            gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
 