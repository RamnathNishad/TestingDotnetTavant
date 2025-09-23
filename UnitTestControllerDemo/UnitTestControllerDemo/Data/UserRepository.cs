using UnitTestControllerDemo.Models;

namespace UnitTestControllerDemo.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext dbCtx;
        public UserRepository(UserDbContext ctx)
        {
            this.dbCtx = ctx;            
        }
        public User AddUser(User user)
        {
            dbCtx.Users.Add(user);
            dbCtx.SaveChanges();

            return user;
        }

        public User DeleteUser(int id)
        {
            var record = dbCtx.Users.Find(id);
            if (record != null)
            {
                dbCtx.Users.Remove(record);
                dbCtx.SaveChanges();
            }
            return record;
        }

        public List<User> GetAllUsers()
        {
            return dbCtx.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return dbCtx.Users.Find(id);
        }

        public User UpdateUser(User user)
        {
            var record = dbCtx.Users.Find(user.Id);

            record.Name=user.Name;
            dbCtx.SaveChanges();

            return record;
        }
    }
}
