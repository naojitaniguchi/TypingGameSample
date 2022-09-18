using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using TMPro;


public class TypingManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI furiganaText;
    [SerializeField] TMPro.TextMeshProUGUI questionText;
    [SerializeField] TMPro.TextMeshProUGUI answerText;
    [SerializeField] TMPro.TextMeshProUGUI correctText;
    [SerializeField] Timer lifeTimer;
    [SerializeField] string ResultSceneName;

    [SerializeField] string[] firiganas;
    [SerializeField] string[] questions;
    [SerializeField] string[] answers;
    [SerializeField] float[] timers;

    [SerializeField] float startWaitTime = 2.0f;
    [SerializeField] float resultWaitTime = 2.0f;
    [SerializeField] GameObject endGameTimeline;

    int questionIndex = -1;
    int targetIndex = 0;

    public int correctCount;
    public int missCount;
    public int score;
    public enum GAME_STATUS
    {
        START,
        GAME,
        END
    }

    public GAME_STATUS status;
    string targetString;
    string correctString;

    // Start is called before the first frame update
    void Start()
    {
        furiganaText.text = "taipinngujigoku";
        questionText.text = "タイピング地獄";
        answerText.text = "taipinngujigoku";

        status = GAME_STATUS.START;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (status == GAME_STATUS.GAME) {
            if (Input.GetKeyDown(targetString[targetIndex].ToString()))
            {
                Correct();
            }
            else if (Input.anyKeyDown)
            {
                Miss();
            }
        }
    }

    private void Correct()
    {
        correctCount++;
        correctString = targetString.Substring(0, targetIndex + 1);
        correctText.text = correctString;

        targetIndex++;

        if ( targetIndex >= targetString.Length)
        {
            score++;
            setNextQuestion();
        }

    }

    private void Miss()
    {
        // Debug.Log("miss");
        missCount++;
    }

    public void setNextQuestion()
    {
        questionIndex++;

        // Debug.Log(questionIndex);
        // lifeTimer.StopTimer();


        if (questionIndex >= firiganas.Length)
        {
            // GameClear
            status = GAME_STATUS.END;
            endGame();
            lifeTimer.StopTimer();
        }
        else
        {
            correctString = "";
            targetIndex = 0;

            furiganaText.text = firiganas[questionIndex];
            questionText.text = questions[questionIndex];
            answerText.text = answers[questionIndex];
            targetString = firiganas[questionIndex];
            correctText.text = correctString;
            lifeTimer.StartTimer(timers[questionIndex]);
        }

        
    }

    public void startGame()
    {
        correctCount = 0;
        missCount = 0;
        score = 0;
        StartCoroutine(startGameCoroutine());
    }


    IEnumerator startGameCoroutine()
    {
        yield return new WaitForSeconds(startWaitTime);

        status = GAME_STATUS.GAME;
        setNextQuestion();
    }

    public void timeUp()
    {
        setNextQuestion();
    }

    private void endGame()
    {
        endGameTimeline.SetActive(true);

        StartCoroutine(loadResultCoroutine());
    }

    IEnumerator loadResultCoroutine()
    {
        yield return new WaitForSeconds(resultWaitTime);

        SceneManager.LoadScene(ResultSceneName);
    }

}
