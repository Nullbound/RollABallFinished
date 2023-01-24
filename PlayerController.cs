using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public int score;
    public int objective = 0;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI timerText;

    public float totalTime;
    private float timeLeft;
    private bool gameWon;
    private bool objFalse;

    public GameObject reset;
    public GameObject next;
    public TextMeshProUGUI tutorial;

    void Start ()
    {
        rb = GetComponent<Rigidbody> ();

        winText.text = "";
        loseText.text = "";
        countText.text = "Score: ";
        timerText.text = "Time: " + timeLeft.ToString();

        timeLeft = totalTime;
        gameWon = false;
        objFalse = false;

        reset.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal,0,moveVertical);

        rb.AddForce (movement * speed);

        timerText.text = "Timer: " + timeLeft.ToString();
        if(gameWon == false)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = string.Format("Time: {0:#.00}" , timeLeft);
            if(timeLeft < 0)
            {
                gameObject.SetActive(objFalse);
                timerText.text = "Timer: 0.00";
            }
            if(gameObject.activeInHierarchy == false)
            {
                loseText.text = "GAME OVER";
                reset.gameObject.SetActive(true);
                tutorial.text = ""; 
            }
        }

        if(score == objective)
        {
            Objective();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            countText.text = "Score: " + score.ToString();
            //Debug.Log("score = " + score);
        }
    }

    void Objective()
    {
        gameObject.SetActive(false);
        winText.text = "LEVEL PASSED";
        next.gameObject.SetActive(true);
        tutorial.text = "";
    }

  
}


