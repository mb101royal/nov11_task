using nov_11_task.Models;

namespace nov_11_task.Service
{
    internal static class BlogService
    {
		public static void AddBlog(Blog blog)
		{
			BlogDatabase.Blogs.Add(blog);
			Console.WriteLine("Blog added.");
		}

		public static void RemoveBlog(int id)
		{
			var blogToRemove = BlogDatabase.Blogs.Find(blog => blog.Id == id);
			if (blogToRemove != null)
			{
				BlogDatabase.Blogs.Remove(blogToRemove);
				Console.WriteLine("Blog removed.");
			}
			else
			{
				Console.WriteLine("Blog not found.");
			}
		}

		public static void GetBlogById(int id)
		{
			var blog = BlogDatabase.Blogs.Find(b => b.Id == id);
			if (blog != null)
			{
				Console.WriteLine($"Title: {blog.Title}\nDescription: {blog.Description}");
			}
			else
			{
				Console.WriteLine("Blog not found.");
			}
		}

		public static void GetAllBlogs()
		{
			foreach (var blog in BlogDatabase.Blogs)
			{
				Console.WriteLine($"ID: {blog.Id}, Title: {blog.Title}");
			}
		}

		public static void GetBlogsByValue(string value)
		{
			var filteredBlogs = BlogDatabase.Blogs.FindAll(blog =>
				blog.Title.Contains(value, StringComparison.OrdinalIgnoreCase) ||
				blog.Description.Contains(value, StringComparison.OrdinalIgnoreCase));

			if (filteredBlogs.Count > 0)
			{
				Console.WriteLine("Filtered Blogs:");
				foreach (var blog in filteredBlogs)
				{
					Console.WriteLine($"ID: {blog.Id}, Title: {blog.Title}");
				}
			}
			else
			{
				Console.WriteLine("No blogs found with the given filter value.");
			}
		}
	}
}
