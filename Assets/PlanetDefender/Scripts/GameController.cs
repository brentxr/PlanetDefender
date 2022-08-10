using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;

    private int playerScore;
    private float sliderCurrentFillAmount = 1.0f;

    [Header("Score Components")] 
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Game Over Component")]
    [SerializeField] private GameObject gameOverScreen;

    [Header("High Score Components")] 
    [SerializeField] private TextMeshProUGUI highScoreText;

    [Header("Gameplay Audio")] 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] gameplayAudio;

    public enum GameState
    {
        Waiting,
        Playing,
        GameOver
    }

    public static GameState currentGameState;


    private void Awake()
    {
        currentGameState = GameState.Waiting;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = "" + PlayerPrefs.GetInt("HighScore");
        }
    }

    private void Update()
    {
        if (currentGameState == GameState.Playing)
            AdjustTime();
    }

    private void AdjustTime()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);
        sliderCurrentFillAmount = timerImage.fillAmount;

        if (sliderCurrentFillAmount <= 0f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        currentGameState = GameState.GameOver;
        
        gameOverScreen.SetActive(true);

        if (playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = "" + playerScore;
        }
        
        PlayGameAudio(gameplayAudio[2], false);
    }

    public void UpdatePlayerScore(int asteroidHitPoints)
    {
        if (currentGameState != GameState.Playing)
            return;
        playerScore += asteroidHitPoints;
        scoreText.text = "" + playerScore;
    }

    public void StartGame()
    {
        PlayGameAudio(gameplayAudio[1], true);
        currentGameState = GameState.Playing;
    }
    
    public void ResetGame()
    {
        currentGameState = GameState.Waiting;
        playerScore = 0;
        scoreText.text = "" + playerScore;
        sliderCurrentFillAmount = 1f;
        timerImage.fillAmount = 1f;
        
        PlayGameAudio(gameplayAudio[0], true);
    }

    private void PlayGameAudio(AudioClip clip, bool shouldLoop)
    {
        audioSource.clip = clip;
        audioSource.loop = shouldLoop;
        audioSource.Play();
    }
}
