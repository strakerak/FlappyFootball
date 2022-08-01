using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //BLOCK 1

    private int score;

    //BLOCK 2 AND ADD UnityEngine.UI
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject backButton;
    public Player player;

    //BLOCK 4
    public GameObject selectedSkin;
    private Sprite playerSprite;

    //BLOCK 2
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {

        //BLOCk 4
        playerSprite = selectedSkin.GetComponent<SpriteRenderer>().sprite;
        player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        //END BLOCK 4

        score = 0;
        scoreText.text = score.ToString();
        gameOver.SetActive(false);
        playButton.SetActive(false);
        backButton.SetActive(false);
        

        player.transform.position = new Vector3(0,0,0);

        Time.timeScale = 1f;

        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i =0; i < pipes.Length;i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; //Pauses the game
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        backButton.SetActive(true);
        scoreText.text = "";



        Pause();
    }

    public void IncreaseScore()
    {
        Debug.Log("SCORE!");
        score++;
        scoreText.text = score.ToString();
    }

    public void GoBack()
    {
        SceneManager.LoadScene("HomePage");
    }

    
}
