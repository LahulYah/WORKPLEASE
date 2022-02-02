using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver = false;

    public GameObject gameOverUi;

    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
        {

            return;
        }
        if (PlayerStats.lives <= 0)
        {

            EndGame();
        }
    }
    void EndGame()
    {
        gameIsOver = true;
        gameOverUi.SetActive(true);
    }
}
