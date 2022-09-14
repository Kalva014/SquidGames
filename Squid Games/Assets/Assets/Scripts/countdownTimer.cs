using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour
{
    public GameObject canvas;
    public Text timeText;
    public GameObject player;
    public float readyTimer = 5;
    public float timeRemaining = 120;
    public bool timerRunning = false;
    

    // Start is called before the first frame update
    void Start()
    {
        canvas.GetComponent<Image>().color = new Color(0, 0, 0);
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyTimer > 0)
        {
            readyTimer -= Time.deltaTime;
            DisplayTime(readyTimer);
        }
        else
        {
            readyTimer = 0;
            if (timeRemaining > 0 && readyTimer == 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                SceneManager.LoadScene(4);
            }
        }
        

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (player.GetComponent<Transform>().position.z > -11.97)
            timeText.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }
}
