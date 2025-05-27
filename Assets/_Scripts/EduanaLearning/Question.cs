using System.Collections.Generic;

public struct Question
{
    public string text;
    public Dictionary<string, Answer> answers;
    public string correct_answer_id;
}
