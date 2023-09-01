namespace CodeSmells
{
    internal interface IUI
    {
        void PutString(string input);
        string GetString();
        void Clear();
        void Exit();
    }
}
