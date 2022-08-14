using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
/*using UnityEditor.Experimental.UIElements.GraphView;*/
/*using UnityEditor.Animations;*/
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] private BallMovement _Bm;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject[] _TilePosition;
    [SerializeField] private GameObject[] _TilePrefab;
    [SerializeField] private GameObject[] _Level;
    [SerializeField] private GameObject[] _SpawnPowerUp;

    [SerializeField] private int[] _lvl1Position, _lvl2Position, _lvl3Position, _lvl4Position, _lvl5Position, _lvl6Position, _lvl7Position;

    [SerializeField] private GameObject _Tile;
    [SerializeField] private GameObject _BottomWall;
    [SerializeField] private GameObject _DoubleBall;
    [SerializeField] private GameObject _GameArea;
    [SerializeField] private GameObject _GameOver;
    [SerializeField] private GameObject _GameComplete;
    [SerializeField] private GameObject _HomePage;
    [SerializeField] private GameObject _WinPage;
    [SerializeField] private GameObject _powerUp;

    [SerializeField] private Text _KillText;
    [SerializeField] private Text _GameOverScore;
    [SerializeField] private Text _Lives;

    [SerializeField] private AudioClip _GameOverClip,_LevelCompClip,_GameCompClip;
    
    public  int Brickcount;

    public int LivesCount = 3;
    private int flag;
    private int i;
    private int randomPos;

    private float x;
    private float y;

    private int level;

    private string levelOpen;

    void Start()
    {
        instance = this;

        _KillText.text = "Score:" + Brickcount;
        _Lives.text = "Life:" + LivesCount;

                                                        //Save Progress
        level = PlayerPrefs.GetInt("levels", 1);
        Debug.Log("Level"+level);

        switch (level)
        {
            case 1:

                Brickcount = 0;
              
                break;
            case 2:

                Brickcount = 90;
              
                break;

            case 3:
                Brickcount = 190;
                break;

            case 4:
                Brickcount = 310;
                break;

            case 5:
                Brickcount = 410;
                break;

            case 6:
                Brickcount = 520;
                break;
            case 7:
                Brickcount = 620;
                break;


        }
        _KillText.text = "Score:"+Brickcount.ToString();


        //  SetScore();
        // _GameArea.SetActive(false);
        _GameComplete.SetActive(false);
        _GameOver.SetActive(false);
        _HomePage.SetActive(true);
        _WinPage.SetActive(false);

        flag = PlayerPrefs.GetInt("retry", 0);
        if (flag == 1)
        {
                Debug.Log("");
         OpenLvl(level);
          PlayerPrefs.SetInt("retry",0);
            _HomePage.SetActive(false);
            _GameArea = GameObject.Find(levelOpen).transform.parent.gameObject;
            Spawn();
           // SetScore();
            setTilePosition();
        }
        else
        {
            _HomePage.SetActive(true);
        }
    }

    public void OpenLvl(int level)
    {
         levelOpen = "level" + level;
        Debug.Log("level is"+ levelOpen);
       
        GameObject.Find(levelOpen).gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    void Update()
    {
        _Lives.text = "Life:" + LivesCount;
       
    }

   
    public void UpdateScore()
    {
        Brickcount+=5;
        _KillText.text = "Score:" + Brickcount;
        _GameOverScore.text = Brickcount.ToString();

        if(Brickcount==90 || Brickcount == 190 || Brickcount == 310 || Brickcount == 410 || Brickcount == 520 || Brickcount == 620 || Brickcount == 740)
                 LoadLevel();
    }
    
    public void UpdateLives()
    {
        if (GameObject.FindWithTag("Ball (Double)"))
        {
            LivesCount = LivesCount;
        }
        else
        {
            LivesCount--;
        }
    }

    private void setTilePosition()
    {
        foreach (Transform child in _Tile.transform)
        {
            if (child.gameObject.tag == "Main Tile")
                GameObject.Destroy(child.gameObject);
        }

        switch (levelOpen)
        {
            case "level1":
                for (int j = 0; j < _lvl1Position.Length; j++)
                {

                    randomPos = Random.Range(0, 4);
                    Instantiate(_TilePrefab[randomPos], _TilePosition[_lvl1Position[j]].transform.position,
                        _TilePrefab[randomPos].transform.rotation, _Tile.transform);
                }

                break;

            case "level2":
                for (int j = 0; j < _lvl2Position.Length; j++)
                {

                    randomPos = Random.Range(0, 4);
                    Instantiate(_TilePrefab[randomPos], _TilePosition[_lvl2Position[j]].transform.position,
                        _TilePrefab[randomPos].transform.rotation, _Tile.transform);
                }

                break;

            case "level3":
                for (int j = 0; j < _lvl3Position.Length; j++)
                {

                    randomPos = Random.Range(0, 4);
                    Instantiate(_TilePrefab[randomPos], _TilePosition[_lvl3Position[j]].transform.position,
                        _TilePrefab[randomPos].transform.rotation, _Tile.transform);
                }

                break;
            case "level4":
                for (int j = 0; j < _lvl4Position.Length; j++)
                {

                    randomPos = Random.Range(0, 4);
                    Instantiate(_TilePrefab[randomPos], _TilePosition[_lvl4Position[j]].transform.position,
                        _TilePrefab[randomPos].transform.rotation, _Tile.transform);
                }

                break;
            case "level5":

                for (int j = 0; j < _lvl5Position.Length; j++)
                {

                    randomPos = Random.Range(0, 4);
                    Instantiate(_TilePrefab[randomPos], _TilePosition[_lvl5Position[j]].transform.position,
                        _TilePrefab[randomPos].transform.rotation, _Tile.transform);
                }

                break;
            case "level6":

                for (int j = 0; j < _lvl6Position.Length; j++)
                {

                    randomPos = Random.Range(0, 4);
                    Instantiate(_TilePrefab[randomPos], _TilePosition[_lvl6Position[j]].transform.position,
                        _TilePrefab[randomPos].transform.rotation, _Tile.transform);
                }

                break;

            case "level7":

                for (int j = 0; j < _lvl7Position.Length; j++)
                {

                    randomPos = Random.Range(0, 4);
                    Instantiate(_TilePrefab[randomPos], _TilePosition[_lvl7Position[j]].transform.position,
                        _TilePrefab[randomPos].transform.rotation, _Tile.transform);
                }

                break;

        }
}

                                                                   //POWERUP SPAWN
    public void Spawn()
    {
        
        i = Random.Range(0, 3);
       
        x = Random.Range(-8, 8);
        y = Random.Range(6.5f, 8.0f);

        if (GameObject.Find("LvlComplete Page") || GameObject.Find("GameOver_Page") || GameObject.Find("GameComplete Page"))
        {
            StopCoroutine(SpawnDelay());
        }
        else
        {
            Instantiate(_SpawnPowerUp[i], new Vector3(x, y, _SpawnPowerUp[i].transform.position.z),
                _SpawnPowerUp[i].transform.rotation, _powerUp.transform);
            StartCoroutine(SpawnDelay());
        }

    }

    IEnumerator SpawnDelay()
    {
        
       // Debug.Log("enter delay");
        yield return new WaitForSeconds(20.0f);
        Spawn();
    }

                                                                //  POWER UP
    public void Life()
    {
        LivesCount++;
    }

    public void LifeLine()
    {
        _BottomWall.SetActive(true);
    }

    public void Double()
    {
        GameObject newBall = Instantiate(_DoubleBall, new Vector2(Random.Range(-8.06f, 8.06f), Random.Range(-2,0)),this.transform.rotation) as GameObject;
        newBall.transform.SetParent(_GameArea.transform.GetChild(0), false);
        newBall.transform.localScale = new Vector3(3.19f, -3.06f, 0);
    }


                                                                      //  BUTTONS

    
    private void LoadLevel()
    {
        _WinPage.SetActive(true);
        _WinPage.GetComponent<AudioSource>().PlayOneShot(_LevelCompClip);
        switch (Brickcount)
        {
            case 90:

                _Level[0].SetActive(false);
                break;

            case 190:
                _Level[1].SetActive(false);

                break;

            case 310:
               
                _Level[2].SetActive(false);
                break;

            case 410:
               
                _Level[3].SetActive(false);
                break;

            case 520:

                Debug.Log("level 5 played");
                _Level[4].SetActive(false);
                break;

            case 620:

                _Level[5].SetActive(false);
                break;

            case 740:
                _Level[6].SetActive(false);
                _Lives.gameObject.SetActive(false);
                _KillText.gameObject.SetActive(false);
                _WinPage.SetActive(false);
                _GameComplete.SetActive(true);

                PlayerPrefs.DeleteKey("levels");
                PlayerPrefs.DeleteAll();
                _GameComplete.GetComponent<AudioSource>().PlayOneShot(_GameCompClip);
                
                break;
        }
    }

    
    public void NextLevel()
    {

        _WinPage.SetActive(false);
                switch (Brickcount)
        {
            case 90:
                OpenLvl(2);
                PlayerPrefs.SetInt("levels", 2);
                _GameArea = _Level[1];
                break;

            case 190:
                OpenLvl(3);

                PlayerPrefs.SetInt("levels", 3);
                _GameArea = _Level[2];
                break;

            case 310:
                OpenLvl(4);
                PlayerPrefs.SetInt("levels", 4);
                
                _GameArea = _Level[3];
                break;

            case 410:
                OpenLvl(5);
                PlayerPrefs.SetInt("levels", 5);
                
                _GameArea = _Level[4];
                break;

            case 520:
                Debug.Log("level 6 loaded");
                OpenLvl(6);
                PlayerPrefs.SetInt("levels", 6);

                _GameArea = _Level[5];
                break;

            case 620:
                OpenLvl(7);
                PlayerPrefs.SetInt("levels", 7);

                _GameArea = _Level[6];
                break;

            default:
               OpenLvl(1);
               PlayerPrefs.SetInt("levels", 1);
                break;

        }
                setTilePosition();
                
              


    }
    

    public void home()
    {
        Time.timeScale = 1f;
        Debug.Log("home");
        SceneManager.LoadScene("First");
        
    }
    public void ready()
    {
        
         _HomePage.SetActive(false);
         OpenLvl(level);
         LoadLevel();
         NextLevel();
         setTilePosition();
         Spawn();
        
       
    }

    public void retry()
    {
       // Spawn();
        SceneManager.LoadScene("First");
        PlayerPrefs.SetInt("retry",1);
        
    }

    public void exit()
    {
        Application.Quit();
    }
                                                                         //  FUNCTIONS
    public void GameOver()
    {
        foreach (Transform child in _Tile.transform)
        {
            if (child.gameObject.tag == "Main Tile")
                GameObject.Destroy(child.gameObject);
        }
        _GameArea.SetActive(false);
      
        _GameOver.SetActive(true);
        _GameOver.GetComponent<AudioSource>().PlayOneShot(_GameOverClip);
    }

    private void SetScore()
    {
            // Brickcount = 0;
            _KillText.gameObject.SetActive(true);
           
    }

}

