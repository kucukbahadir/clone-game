using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Question
{
    public string text;
    [SerializeField]public Dictionary<string, Answer> answers;
    public string correct_answer_id;
    public string correct_answer_description;
}
