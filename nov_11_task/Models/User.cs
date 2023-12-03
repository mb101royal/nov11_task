using nov_11_task.Exceptions;

namespace nov_11_task.Models
{
    internal class User
    {
		static int IdCounter = 1;
		public int Id { get; }
		public string Name { get; }
		public string Surname { get; }
		public string Username { get; }
		public string Password { get; }

		public User(string name, string surname, string password)
		{
			if (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit))
			{
				throw new InvalidNameException("Invalid name.");
			}

			if (string.IsNullOrWhiteSpace(surname) || surname.Any(char.IsDigit))
			{
				throw new InvalidSurnameException("Invalid surname.");
			}

			if (password.Length < 8 || !char.IsUpper(password[0]) || !password.Any(char.IsDigit))
			{
				throw new InvalidPasswordException("Invalid password.");
			}

			Id = IdCounter;
			IdCounter++;
			Name = name;
			Surname = surname;
			Username = $"{name.ToLower()}.{surname.ToLower()}";
			Password = password;
		}
	}
}
