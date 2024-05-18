using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mathGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        inningText.text = $"{count}/{changeDiff.numberCount}";

        GenerateRandomProbem();
        score = 0;
        right = 0;
        scoreText.text = score.ToString();
        popup.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        string minutes = ((int)pastTime / 60).ToString("00");
        string seconds = ((int)pastTime % 60).ToString("00");

        showTime.text = $"{minutes} : {seconds}";

        if (activeTimer)
        {
            pastTime += Time.deltaTime;
        }

        if (count > changeDiff.numberCount)
        {
            activeTimer = false;
            popup.SetActive(true);
            rightResult.text = $"You answered {right} questions correctly. Using {minutes} : {seconds}.";
        }

    }

    public UnityEngine.UI.Text number1Text;
    public UnityEngine.UI.Text number2Text;
    public UnityEngine.UI.Text operatorText;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text inningText;
    public UnityEngine.UI.Text rightResult;
    public UnityEngine.UI.Text showTime;
    public UnityEngine.UI.InputField answerInput;
    public GameObject popup;
    

    public int number1;
    public int number2;
    public string operatorSymbol;
    public int correctAnswer;
    public int score;
    public int operatorIndex;
    public int count = 1;
    public int playAnswer;
    public int right;
    public int palyerChosen = changeDiff.numberCount;

    public float pastTime=0;

    public bool result = false;
    public bool activeTimer = true;

    public List<string> histories = new List<string>();

    public static mathGame current;

    void Awake()
    {
        current = this;
    }

    public void StoreHistory()
    {

        histories.Add($"{count}. {number1}{operatorSymbol}{number2}={playAnswer} {result} Answer: {correctAnswer}");
    }

    public string ReadHistory()
    {
        string historyData = "";

        foreach(string history in histories)
        {
            historyData += history + "\n";
        }

        return historyData;
    }

    public void GenerateRandomProbem()
    {
        switch (changeDiff.difficulty)
        {
            case 0:
                number1 = UnityEngine.Random.Range(0, 11);
                number2 = UnityEngine.Random.Range(0, 11);

                if (changeDiff.operation == 4)
                {
                    operatorIndex = UnityEngine.Random.Range(0, 4);
                }
                else
                {
                    operatorIndex = changeDiff.operation;
                }
                
                switch (operatorIndex)
                {
                    case 0:
                        operatorSymbol = "+";
                        correctAnswer = number1 + number2;
                        break;
                    case 1:
                        operatorSymbol = "-";
                        correctAnswer = number1 - number2;
                        break;
                    case 2:
                        operatorSymbol = "*";
                        correctAnswer = number1 * number2;
                        break;
                    case 3:
                        operatorSymbol = "/";
                        do
                        {
                            number1 = UnityEngine.Random.Range(0, 11);
                            number2 = UnityEngine.Random.Range(1, 11);//avoid divide by zero
                        }
                        while (number1 <= number2 || number1 % number2 != 0);

                        correctAnswer = number1 / number2;
                        break;
                }
                number1Text.text = number1.ToString();
                number2Text.text = number2.ToString();
                operatorText.text = operatorSymbol;
                break;
            case 1:
                number1 = UnityEngine.Random.Range(0, 51);
                number2 = UnityEngine.Random.Range(0, 51);

                if (changeDiff.operation == 4)
                {
                    operatorIndex = UnityEngine.Random.Range(0, 4);
                }
                else
                {
                    operatorIndex = changeDiff.operation;
                }

                switch (operatorIndex)
                {
                    case 0:
                        operatorSymbol = "+";
                        correctAnswer = number1 + number2;
                        break;
                    case 1:
                        operatorSymbol = "-";
                        correctAnswer = number1 - number2;
                        break;
                    case 2:
                        operatorSymbol = "*";
                        correctAnswer = number1 * number2;
                        break;
                    case 3:
                        operatorSymbol = "/";
                        do
                        {
                            number1 = UnityEngine.Random.Range(0, 51);
                            number2 = UnityEngine.Random.Range(1, 51);//avoid divide by zero
                        }
                        while (number1 <= number2 || number1 % number2 != 0);

                        correctAnswer = number1 / number2;
                        break;
                }
                number1Text.text = number1.ToString();
                number2Text.text = number2.ToString();
                operatorText.text = operatorSymbol;
                break;
            case 2:
                number1 = UnityEngine.Random.Range(0, 101);
                number2 = UnityEngine.Random.Range(0, 101);

                if (changeDiff.operation == 4)
                {
                    operatorIndex = UnityEngine.Random.Range(0, 4);
                }
                else
                {
                    operatorIndex = changeDiff.operation;
                }

                switch (operatorIndex)
                {
                    case 0:
                        operatorSymbol = "+";
                        correctAnswer = number1 + number2;
                        break;
                    case 1:
                        operatorSymbol = "-";
                        correctAnswer = number1 - number2;
                        break;
                    case 2:
                        operatorSymbol = "*";
                        correctAnswer = number1 * number2;
                        break;
                    case 3:
                        operatorSymbol = "/";
                        do
                        {
                            number1 = UnityEngine.Random.Range(0, 101);
                            number2 = UnityEngine.Random.Range(1, 101);//avoid divide by zero
                        }
                        while (number1 <= number2 || number1 % number2 != 0);

                        correctAnswer = number1 / number2;
                        break;
                }
                number1Text.text = number1.ToString();
                number2Text.text = number2.ToString();
                operatorText.text = operatorSymbol;
                break;
        }
            
    }

    public void ConfirmAnswer()
    {
        int.TryParse(answerInput.text, out playAnswer);


        if (playAnswer == correctAnswer)
        {
            score+=100;
            scoreText.text = score.ToString();
            result = true;
            right++;
        }
        else
        {
            result = false;
        }

        StoreHistory();
        count++;
        inningText.text = $"{count}/{changeDiff.numberCount}";

        GenerateRandomProbem();
    }
}
