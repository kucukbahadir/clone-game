public struct Keyword
{
    public int id;
    public string keywordName;
    public Question[] questions;

    public Keyword(int id, string keywordName, Question[] questions)
    {
        this.id = id;
        this.keywordName = keywordName;
        this.questions = questions;
    }
}
