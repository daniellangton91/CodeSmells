namespace CodeSmellsTests
{
    internal class MockUI : IUI
    {
        public void Clear() => throw new NotImplementedException();

        public void Exit() => throw new NotImplementedException();

        public string GetString() => throw new NotImplementedException();

        public void PutString(string input) => throw new NotImplementedException();
    }
}
