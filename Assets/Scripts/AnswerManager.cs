using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class AnswerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int answerScore = 0;
    [SerializeField] int questionCount = 0;
    [SerializeField] Button Retake;
    [SerializeField] Button Menu;
    [SerializeField] TextMeshProUGUI result;
    public static AnswerManager Instance {get; private set;}
    private void Awake() {
        Instance = this;
    }
    public void AnswerScore()
    {
        answerScore += 1;
    }
    public void isPass()
    {
        if(answerScore < questionCount)
        {
            result.text = "You have Failed";
            Retake.gameObject.SetActive(true);
        }
        else
        {
            result.text = "Congratulations! You have Passed";
            Menu.gameObject.SetActive(true);
        }
    }
}
