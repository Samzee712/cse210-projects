public class Program
{
    public static void Main()
    {
        var videos = new List<Video>
        {
            new Video("How to pray everyday", "John Sam", 120),
            new Video("How to Make Money Online", "Young Phillips", 150),
            new Video("Learn How To Study The Scriptures Everyday", "John White", 200)
        };

        videos[0].AddComment(new Comment("John", "Great video!"));
        videos[0].AddComment(new Comment("Clinton", "Thanks for sharing."));
        videos[0].AddComment(new Comment("Emmanuel", "Very informative."));

        videos[1].AddComment(new Comment("Sam", "Loved it!"));
        videos[1].AddComment(new Comment("Joesph", "Awesome content."));

        videos[2].AddComment(new Comment("Godsgift", "Well explained."));
        videos[2].AddComment(new Comment("Joe", "Inspirational, Thank you for sharing this content."));

        foreach (var video in videos)
        {
            video.Display();
        }
    }
}