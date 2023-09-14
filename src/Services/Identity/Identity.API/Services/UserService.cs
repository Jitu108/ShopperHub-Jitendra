using Identity.API.Data;
using Identity.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext context;

        public UserService(UserContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddPerson(Person person)
        {
            await context.People.AddAsync(person);
            var status = await context.SaveChangesAsync();

            return status > 0;
        }

        public async Task<Person> GetUserByEmail(string email)
        {
            var user = await context.People.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<Person> GetUserById(int id)
        {
            var user = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            var hasUser = await context.People.AnyAsync(x => x.Email == email && x.Password == password);

            return hasUser;
        }
    }
}
