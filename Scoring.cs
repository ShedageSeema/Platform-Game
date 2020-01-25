using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {
    public TextMesh text;
    public float timeLeft = 100.0f;
    public int score = 0;
    public int level = 1;
    public GameObject player;
    public GameObject wall;
    public float threshold = 0.1f;
    public float thresholdForFalling = -0.1f;
    Vector3 initialPosition;
    // Use this for initialization
    void Start()
    {
        initialPosition = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (score >= 2 && timeLeft > 0.0f)
        {
            text.text = "You win";
            ///winning message
        }
        else if (timeLeft > 0.0f)
        {
            ///notify the user with score and time
            text.text = "Level:" + level + " Score:" + score + " Time:" + timeLeft;

        }
        else if (timeLeft < 0.0f)
        {
            ///lose..notify the user
            text.text = "You lost...Sorry!!";


        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(player.transform.position.z - wall.transform.position.z)
            < threshold)
        {
            score++;
            player.transform.position = initialPosition;


        }
        if (player.transform.position.y < thresholdForFalling)
        {
            score--;
            player.transform.position = initialPosition;

        }

        if (score >= 2)
        {
            if (level == 1)
            {
                ///load the next level level2.
                ///
                Debug.Log("Level2..");

            }
            score = 0;
            timeLeft = 100.0f;
            player.transform.position = initialPosition;


        }

    }
}


