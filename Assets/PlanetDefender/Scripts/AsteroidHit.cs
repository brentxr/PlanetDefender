using TMPro;
using UnityEngine;


public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    [SerializeField] private GameObject popupCanvas;

    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void AsteroidDestroyed()
    {
        Instantiate(asteroidExplosion, transform.position, transform.rotation);

        if (GameController.currentGameState == GameController.GameState.Playing)
        {
            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
            int bonusPoints = (int)distanceFromPlayer;

            int asteroidScore = 10 * bonusPoints;

            popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + asteroidScore;
            var asteropidPopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);

            asteropidPopup.transform.localScale = new Vector3(
                transform.localScale.x * (distanceFromPlayer / 10),
                transform.localScale.y * (distanceFromPlayer / 10),
                transform.localScale.z * (distanceFromPlayer / 10));
        
            gameController.UpdatePlayerScore(asteroidScore);
        }
        
        
        Destroy(this.gameObject);
    }
    
}
