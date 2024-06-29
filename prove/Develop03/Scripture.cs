using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        public Reference Reference { get; }
        public string Text { get; private set; }
        private List<Word> words;
        private Random random;

        public int WordsHidden => words.Count(w => w.IsHidden);
        public int TotalWords => words.Count;

        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Text = text;
            words = new List<Word>();
            random = new Random();
            foreach (var word in text.Split(' '))
            {
                words.Add(new Word(word));
            }
        }

        public bool HideRandomWords()
        {
            var visibleWords = words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count == 0)
                return false;

            int wordsToHide = Math.Min(3, visibleWords.Count); // hide up to 3 words at a time
            for (int i = 0; i < wordsToHide; i++)
            {
                var wordToHide = visibleWords[random.Next(visibleWords.Count)];
                wordToHide.Hide();
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Reference}\n{string.Join(' ', words)}";
        }
    }
}
