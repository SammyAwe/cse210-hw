using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // length in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int NumberOfComments()
    {
        return Comments.Count;
    }

    public override string ToString()
    {
        string commentsStr = string.Join("\n", Comments);
        return $"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds\nNumber of Comments: {NumberOfComments()}\nComments:\n{commentsStr}";
    }
}

class Program
{
    static void Main()
    {
        
        Video video1 = new Video("Product Review 1", "Reviewer1", 600);
        Video video2 = new Video("Product Review 2", "Reviewer2", 720);
        Video video3 = new Video("Product Review 3", "Reviewer3", 900);

        video1.AddComment(new Comment("UserA", "Great review!"));
        video1.AddComment(new Comment("UserB", "Very helpful, thanks!"));
        video1.AddComment(new Comment("UserC", "Could you review the next model?"));

        video2.AddComment(new Comment("UserD", "Nice video!"));
        video2.AddComment(new Comment("UserE", "I didn't find this useful."));
        video2.AddComment(new Comment("UserF", "Can you do a comparison with other products?"));

        video3.AddComment(new Comment("UserG", "Awesome content!"));
        video3.AddComment(new Comment("UserH", "This was very informative."));
        video3.AddComment(new Comment("UserI", "Looking forward to more videos."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine(new string('-', 50));
        }
    }
}