using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _PausePage;
    [SerializeField] private GameObject _Tile;
    [SerializeField] private GameObject _Pause;

    private void Start()
    {
        _PausePage.SetActive(false);
       // _PausePage.SetActive(false);
    }

    public void pause()
    {
         _Pause.SetActive(false);
        _PausePage.SetActive(true);
        _Tile.SetActive(false);
        Time.timeScale = 0f;
    }

    public void unPause()
    {
       _Pause.SetActive(true);
        _Tile.SetActive(true);
        _PausePage.SetActive(false);
        Time.timeScale = 1f;
        
    }
}
