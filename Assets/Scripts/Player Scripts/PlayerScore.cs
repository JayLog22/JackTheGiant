using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private bool countScore;

    private Vector3 previousPosition;

    public static int scoreCount;
    public static int lifeScore;
    public static int coinScore;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }

            previousPosition = transform.position;
            GameplayController.instance.SetScore(scoreCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin")
        {
            coinScore++;
            scoreCount += 200;
            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetCoinScore(coinScore);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Life")
        {
            lifeScore++;
            scoreCount += 300;
            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeScore);
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Bounds" || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeScore--;
            GameManager.instance.CheckGameStatus(scoreCount, coinScore, lifeScore);
        }


    }
}
