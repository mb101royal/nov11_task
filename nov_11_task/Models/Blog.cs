namespace nov_11_task.Models
{
    internal class Blog
    {
		static int IdCounter = 1;
		public int Id { get; }
		public string Title { get; }
		public string Description { get; }
		public BlogType Type { get; }

		public Blog(string title, string description, BlogType type)
		{
			Id = IdCounter;
			IdCounter++;
			Title = title;
			Description = description;
			Type = type;
		}
	}

    public enum BlogType
    {
        Programming = 1,
        Educational,
        Thriller
    }
}
