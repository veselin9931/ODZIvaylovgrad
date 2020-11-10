using ODZ.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public interface IUserService
    {
        public Task<ApplicationUser> Authenticate(string username, string password);
        IEnumerable<ApplicationUser> GetAll();
        public ApplicationUser GetById(string id);
        Task<ApplicationUser> Create(ApplicationUser user, string password);
        void Delete(string id);
    }
}
