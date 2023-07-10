
using TellariniPietro.model;
using TellariniPietro.common;

namespace TellariniPietro.Controllers
{
    /// <summary>
    /// The controller of the user.
    /// </summary>
    public class UserController
    {
        private const int MAX_PLAYER = 5;
        private const string USER_FILE = "user.json";
        private readonly List<User> users;

        /// <summary>
        /// Empty UserController constructor.
        /// </summary>
        public UserController()
        {
            this.users = JsonUtils.LoadData<List<User>>(USER_FILE) ?? new List<User>();
        }

        /// <summary>
        /// Method to save the users.
        /// </summary>
        public void SaveUsers()
        {
            JsonUtils.SaveData(this.users, USER_FILE);
        }

        /// <summary>
        /// Method to get all the names of the saved users.
        /// </summary>
        /// <returns>The List of names.</returns>
        public List<string> GetUsersName()
        {
            return this.users.Select(user => user.GetName()).ToList();
        }

        /// <summary>
        /// Method to get a user by name.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <returns>A User object.</returns>
        public User GetUser(string username)
        {
            return this.users.FirstOrDefault(user => user.GetName() == username);
        }

        /// <summary>
        /// Method to add a new user to the JSON file.
        /// </summary>
        /// <param name="newUser">The user to add.</param>
        public void AddUser(User newUser)
        {
            if (!IsMaxUser())
            {
                this.users.Add(newUser);
            }
        }

        /// <summary>
        /// Method to remove a user and their ranks from the JSON file.
        /// </summary>
        /// <param name="username">The name of the user to remove.</param>
        public void RemoveUser(string username)
        {
            this.users.RemoveAll(user => user.GetName() == username);
        }

        /// <summary>
        /// Method to check the number of users.
        /// </summary>
        /// <returns>True if the number of users is less than MAX_PLAYER.</returns>
        public bool IsMaxUser()
        {
            return this.users.Count >= MAX_PLAYER;
        }
    }
}
