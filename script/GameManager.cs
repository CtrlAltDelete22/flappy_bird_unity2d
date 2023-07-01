using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject PlayButton;
    public GameObject gameOver;
    
    private int Score;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void play() 
    {

        Score = 0;
        scoreText.text = Score.ToString();
        PlayButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        pipes[] pipes = FindObjectsOfType<pipes>();
        for(int i=0;i<pipes.Length; i++) 
        {
            Destroy(pipes[i].gameObject);
        }
        
    }
  
    public void Pause() 
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void gameover() 
    {
        gameOver.SetActive(true);
        PlayButton.SetActive(true);
        Pause();
    }
    public void increasescore() 
    {
        Score++;
        scoreText.text = Score.ToString();
    }
}
