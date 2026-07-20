using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Constructor that parses a reference string (e.g., "1 Nephi 3:7" or "2 Nephi 9:28-29")
    public Reference(string referenceString)
    {
        ParseReference(referenceString.Trim());
    }

    // Private helper to parse the reference string
    private void ParseReference(string referenceString)
    {
        // Find the last space which separates the book name from chapter/verse info
        int lastSpaceIndex = referenceString.LastIndexOf(' ');
        _book = referenceString.Substring(0, lastSpaceIndex);
        
        string chapterAndVerses = referenceString.Substring(lastSpaceIndex + 1);
        string[] parts = chapterAndVerses.Split(':');
        _chapter = int.Parse(parts[0]);

        string[] verses = parts[1].Split('-');
        _startVerse = int.Parse(verses[0]);
        
        if (verses.Length > 1)
        {
            _endVerse = int.Parse(verses[1]);
        }
        else
        {
            _endVerse = _startVerse;
        }
    }

    // Returns the reference in readable text format
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}
