using System;

public class Word
{
    private string _text;
    private bool _isHidden;
    private bool _tempShow;

    // Constructor to initialize the word
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
        _tempShow = false;
    }

    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show the word (unhide it)
    public void Show()
    {
        _isHidden = false;
    }

    // Temporarily show the word even if it is hidden
    public void TempShow()
    {
        _tempShow = true;
    }

    // Clear the temporary show state
    public void ClearTempShow()
    {
        _tempShow = false;
    }

    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns either the original word or its hidden representation (underscores)
    public string GetDisplayText()
    {
        // If it is not hidden, or if we are temporarily showing it, return the original text
        if (!_isHidden || _tempShow)
        {
            return _text;
        }

        // Otherwise, replace only letters and digits with underscores to preserve punctuation
        char[] chars = _text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsLetterOrDigit(chars[i]))
            {
                chars[i] = '_';
            }
        }
        return new string(chars);
    }
}
