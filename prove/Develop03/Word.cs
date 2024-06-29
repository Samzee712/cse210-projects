namespace ScriptureMemorizer
{
    public class Word
    {
        private string text;
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            this.text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public override string ToString()
        {
            return IsHidden ? "_____" : text;
        }
    }
}
