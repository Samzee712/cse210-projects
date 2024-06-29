namespace ScriptureMemorizer
{
    public class Reference
    {
        public string Book { get; }
        public string Chapter { get; }
        public string VerseRange { get; }

        public Reference(string book, string chapter, string verseRange)
        {
            Book = book;
            Chapter = chapter;
            VerseRange = verseRange;
        }

        public override string ToString()
        {
            return $"{Book} {Chapter}:{VerseRange}";
        }
    }
}
