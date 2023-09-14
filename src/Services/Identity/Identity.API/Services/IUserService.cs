using Identity.API.Data.Entities;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string email, string password);
        Task<Person> GetUserById(int id);
        Task<Person> GetUserByEmail(string email);
        Task<bool> AddPerson(Person person);
    }
}
