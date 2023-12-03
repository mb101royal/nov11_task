using nov_11_task.Exceptions;
using nov_11_task.Models;

namespace nov_11_task.Services
{
	internal static class UserService
	{
		public static void Register(string name, string surname, string password)
		{
			try
			{
				var user = new User(name, surname, password);
				BlogDatabase.Users.Add(user);
				Console.WriteLine("User registered successfully!");
			}
			catch (InvalidNameException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
			catch (InvalidSurnameException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
			catch (InvalidPasswordException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public static bool Login(string username, string password)
		{
			var user = BlogDatabase.Users.Find(u => u.Username == username && u.Password == password);
			return user != null;
		}
	}
}
