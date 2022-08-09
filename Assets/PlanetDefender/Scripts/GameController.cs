using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;

    private float playerScore;
    private float sliderCurrentFillAmount = 1.0f;

    [Header("Score Components")] 
    [SerializeField] private TextMeshProUGUI scoreText;


    private void Update()
    {
        AdjustTime();
    }

    private void AdjustTime()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);
        sliderCurrentFillAmount = timerImage.fillAmount;
    }

    public void UpdatePlayerScore(int asteroidHitPoints)
    {
        playerScore += asteroidHitPoints;
        scoreText.text = "" + playerScore;
    }
}
