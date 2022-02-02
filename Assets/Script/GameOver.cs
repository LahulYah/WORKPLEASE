using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text wavesText;
    public AudioSource audioSource;
    public AudioClip soundRetry;
    public AudioClip soundMenu;


    private void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();

    }

    public void Retry()
    {
        AudioSource.PlayClipAtPoint(soundRetry, transform.position);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Menu()
    {
        AudioSource.PlayClipAtPoint(soundMenu, transform.position);
        SceneManager.LoadScene(0);

    }
}
