using MongoDB.Driver;
using TaskManagerApp.Server.DbContext;
using TaskManagerApp.Server.Models;


namespace TaskManagerApp.Server.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(MongoDbContext dbContext)
        {
            _users = dbContext.Users;
        }

        public User? GetUserById(string id)
        {
            return _users.Find(u => u.Id == id).FirstOrDefault();
        }

        public User? GetUserByUsername(string username)
        {
            return _users.Find(u => u.UserName == username).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            user.SetPassword(user.PasswordHash); // Hash password before saving
            _users.InsertOne(user);
        }
    }
}
