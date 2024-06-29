using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        return VerseEnd.HasValue ? $"{Book} {Chapter}:{VerseStart}-{VerseEnd}" : $"{Book} {Chapter}:{VerseStart}";
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public override string ToString()
    {
        return Hidden ? "_____" : Text;
    }
}

public class Scripture
{
    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = Regex.Split(text, @"(\W+)").Where(w => !string.IsNullOrWhiteSpace(w)).Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var unhiddenWords = Words.Where(w => !w.Hidden).ToList();
        var random = new Random();
        var wordsToHide = unhiddenWords.OrderBy(x => random.Next()).Take(Math.Min(count, unhiddenWords.Count)).ToList();
        wordsToHide.ForEach(w => w.Hide());
    }

    public override string ToString()
    {
        return $"{Reference}\n" + string.Join(" ", Words);
    }
}

public class Program
{
    private List<Scripture> Scriptures { get; set; }

    public Program()
    {
        Scriptures = new List<Scripture>();
    }

    public void AddScripture(Scripture scripture)
    {
        Scriptures.Add(scripture);
    }

    public void ClearScreen()
    {
        Console.Clear();
    }

    public void Run()
    {
        foreach (var scripture in Scriptures)
        {
            ClearScreen();
            Console.WriteLine(scripture);

            while (scripture.Words.Any(w => !w.Hidden))
            {
                Console.WriteLine("Press Enter to hide words, or type 'quit' to exit:");
                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "quit")
                    return;

                scripture.HideRandomWords(3);
                ClearScreen();
                Console.WriteLine(scripture);
            }

            Console.WriteLine("All words are hidden. Moving to the next scripture.");
        }
    }

    static void Main()
    {
        var reference = new Reference("John", 3, 16);
        var text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        var scripture = new Scripture(reference, text);

        var reference2 = new Reference("Proverbs", 3, 5, 6);
        var text2 = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        var scripture2 = new Scripture(reference2, text2);

        var program = new Program();
        program.AddScripture(scripture);
        program.AddScripture(scripture2);
        program.Run();
    }
}
