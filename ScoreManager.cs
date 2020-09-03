using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int gscore = 0;
    public Text scoreText;
    public GameObject YouWinText;

    void Update()
    {
        scoreText.text = "Score: " + gscore;
        if (gscore >= 20)
        {
            YouWinText.SetActive(true);
        }
    }
}
