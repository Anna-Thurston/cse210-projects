using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ');

        foreach (string part in parts)
        {
            Word word = new Word(part);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int count = 0;

        while (count < numberToHide)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                count++;
            }
        }
    }

    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + " - ";

        foreach (Word word in _words)
        {
            display += word.GetDisplayText() + " ";
        }

        return display.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
