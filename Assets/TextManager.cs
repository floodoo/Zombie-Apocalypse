using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    private int score;
    private int ammo;


    void Start()
    {
        score = 0;
        ammo = 0;
        UpdateScore(0);
        UpdateAmmo(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateAmmo(int ammoToAdd)
    {
        ammo = ammoToAdd;
        ammoText.text = "Ammo: " + ammo.ToString();
    }
}
