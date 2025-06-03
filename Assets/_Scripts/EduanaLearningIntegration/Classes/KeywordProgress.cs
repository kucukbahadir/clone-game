using UnityEngine;

public class KeywordProgress
{
    public int keyword_id;
    public bool result;
    public string answeredAt;

    public KeywordProgress(int keyword_id, bool result, string answeredAt)
    {
        this.keyword_id = keyword_id;
        this.result = result;
        this.answeredAt = answeredAt;
    } 
}
