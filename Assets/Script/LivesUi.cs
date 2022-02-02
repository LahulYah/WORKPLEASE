using UnityEngine.UI;
using UnityEngine;

public class LivesUi : MonoBehaviour
{
    public Text livesText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats.lives + " Lives";
    }
}
