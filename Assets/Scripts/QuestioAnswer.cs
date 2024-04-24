using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestioAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button nextQuestion;
    [SerializeField] TextMeshProUGUI checkAnswer;
    [SerializeField] Button[] options;
    void Start()
    {
        nextQuestion.gameObject.SetActive(false);
        checkAnswer.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CorrectAnswer(Button button)
    {
        AnswerManager.Instance.AnswerScore();
        button.image.color = Color.green;
        checkAnswer.text = "Well done! Correct Answer";  
        checkAnswer.color = Color.green;
        DisableButtons();
        
    }
    public void WrongAnswer(Button button)
    {
        checkAnswer.text = "Wrong Answer";
        button.image.color = Color.red;
        checkAnswer.color = Color.red;
        DisableButtons();
    }
    void DisableButtons()
    {
        nextQuestion.gameObject.SetActive(true);
        foreach(Button btn in options)
        {
            btn.enabled = false;
        }
    }
}
