using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor that takes a Reference object and the scripture text
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text by space and populate the list of Word objects
        string[] wordsArray = text.Split(' ');
        foreach (string wordText in wordsArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    // Hides a specified count of random words that are not already hidden
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        // Get indices of words that are not currently hidden
        List<int> visibleIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndices.Add(i);
            }
        }

        // Return if everything is already hidden
        if (visibleIndices.Count == 0) return;

        // Pick random indices to hide
        int actualToHide = Math.Min(numberToHide, visibleIndices.Count);
        for (int i = 0; i < actualToHide; i++)
        {
            int randomIndex = random.Next(visibleIndices.Count);
            int wordIndex = visibleIndices[randomIndex];
            
            _words[wordIndex].Hide();
            visibleIndices.RemoveAt(randomIndex); // Prevent hiding the same word twice in this call
        }
    }

    // Sets the temp show flag on all words
    public void TempShowAll()
    {
        foreach (Word word in _words)
        {
            word.TempShow();
        }
    }

    // Clears the temp show flag on all words
    public void ClearTempShowAll()
    {
        foreach (Word word in _words)
        {
            word.ClearTempShow();
        }
    }

    // Formats the reference and all words for display
    public string GetDisplayText()
    {
        string textPart = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n\n{textPart}";
    }

    // Returns true if all words in the scripture are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
