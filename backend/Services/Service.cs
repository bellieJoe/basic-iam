

using backend.Models;
using backend.Services.Interface;

namespace backend.Services
{
    public class Service: IService 
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public IAuthService AuthService { get; }
        
        public Service(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
            AuthService = new AuthService(_config, _context);
        }

    }
}
