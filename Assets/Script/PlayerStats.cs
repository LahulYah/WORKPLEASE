using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 300;
    public static int lives;
    public int startLives = 20;
    public static int waves;

    public void Start()
    {
        waves = 0;
        money = startMoney;
        lives = startLives;
    }
}
