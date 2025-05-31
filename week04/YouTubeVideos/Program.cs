using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Tie Shoelaces", "Samuel Costa", 100);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "I was waiting for this watch."));
        video1.AddComment(new Comment("Carol", "Variation details?"));

        Video video2 = new Video("How to Cook Spaghetti", "Brendan Brady", 300);
        video2.AddComment(new Comment("Dave", "Awesome selection!"));
        video2.AddComment(new Comment("Emma", "Where is the sauce?"));
        video2.AddComment(new Comment("Frank", "Loved the homemade pasta."));

        Video video3 = new Video("How to breakdance", "Anna Thurston", 500);
        video3.AddComment(new Comment("Grace", "So helpful!"));
        video3.AddComment(new Comment("Hank", "Clear and concise."));
        video3.AddComment(new Comment("Ivy", "Subscribed!"));

        Video video4 = new Video("How to Cook Chicken", "Ugochukwe Febechukwu", 450);
        video4.AddComment(new Comment("Jake", "Tried this yesterday, amazing."));
        video4.AddComment(new Comment("Laura", "Can you do one on lasagna?"));
        video4.AddComment(new Comment("Mike", "Thanks for the tips!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.GetTitle());
            Console.WriteLine("Author: " + video.GetAuthor());
            Console.WriteLine("Length: " + video.GetLengthInSeconds() + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetCommentCount());
            Console.WriteLine("Comments:");

            List<Comment> comments = video.GetComments();
            foreach (Comment comment in comments)
            {
                Console.WriteLine("- " + comment.GetCommenterName() + ": " + comment.GetText());
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
