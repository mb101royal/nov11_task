using nov_11_task.Models;
using nov_11_task.Service;
using nov_11_task.Services;

namespace nov_11_task
{
	internal class Program
	{
		static void Main(string[] args)
		{
			{
				while (true)
				{
					Console.WriteLine("Menu");
					Console.WriteLine("1. Register");
					Console.WriteLine("2. Login");
					Console.WriteLine("0. Exit");

					int choice;
					if (!int.TryParse(Console.ReadLine(), out choice))
					{
						Console.WriteLine("Invalid input. Please try again.");
						continue;
					}

					switch (choice)
					{
						case 1:
							Console.WriteLine("Enter name:");
							string name = Console.ReadLine();
							Console.WriteLine("Enter surname:");
							string surname = Console.ReadLine();
							Console.WriteLine("Enter password:");
							string password = Console.ReadLine();
							UserService.Register(name, surname, password);
							break;
						case 2:
							Console.WriteLine("Enter username:");
							string username = Console.ReadLine();
							Console.WriteLine("Enter password:");
							string loginPassword = Console.ReadLine();
							if (UserService.Login(username, loginPassword))
							{
								BlogMenu();
							}
							else
							{
								Console.WriteLine("Invalid username or password. Please try again.");
							}
							break;
						case 0:
							Environment.Exit(0);
							break;
						default:
							Console.WriteLine("Invalid choice. Please try again.");
							break;
					}
				}
			}
		}
		public static void BlogMenu()
		{
			while (true)
			{
				Console.WriteLine("Blog Menu");
				Console.WriteLine("1. Add Blog");
				Console.WriteLine("2. Remove Blog");
				Console.WriteLine("3. Blog Details");
				Console.WriteLine("4. Show all Blogs");
				Console.WriteLine("5. Filter Blogs");
				Console.WriteLine("0. End the program");

				int choice;
				if (!int.TryParse(Console.ReadLine(), out choice))
				{
					Console.WriteLine("Invalid input. Please try again.");
					continue;
				}

				switch (choice)
				{
					case 1:
						Console.WriteLine("Enter blog title:");
						string title = Console.ReadLine();
						Console.WriteLine("Enter blog description:");
						string description = Console.ReadLine();
						BlogType blogType;
						while (true)
						{
							Console.WriteLine("Enter blog type (Programming, Educational, Thriller):");
							if (Enum.TryParse(Console.ReadLine(), out blogType) && Enum.IsDefined(typeof(BlogType), blogType))
							{
								break;
							}
							else
							{
								Console.WriteLine("Invalid blog type. Please enter a valid type.");
							}
						}
						BlogService.AddBlog(new Blog(title, description, blogType));
						break;
					case 2:
						Console.WriteLine("Enter blog ID to remove:");
						if (int.TryParse(Console.ReadLine(), out int blogIdToRemove))
						{
							BlogService.RemoveBlog(blogIdToRemove);
						}
						else
						{
							Console.WriteLine("Invalid input. Please enter a valid ID.");
						}
						break;
					case 3:
						Console.WriteLine("Enter blog ID to view details:");
						if (int.TryParse(Console.ReadLine(), out int blogId))
						{
							BlogService.GetBlogById(blogId);
						}
						else
						{
							Console.WriteLine("Invalid input. Please enter a valid ID.");
						}
						break;
					case 4:
						BlogService.GetAllBlogs();
						break;
					case 5:
						Console.WriteLine("Enter filter value:");
						string filterValue = Console.ReadLine();
						BlogService.GetBlogsByValue(filterValue);
						break;
					case 0:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			}
		}
	}
}