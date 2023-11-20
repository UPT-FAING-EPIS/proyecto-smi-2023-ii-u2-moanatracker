using Supabase;
using Supabase.Storage.Exceptions;
using System;
using System.Threading.Tasks;

namespace Moana
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly Supabase.Client _supabase;

        public AuthenticationService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                var response = await _supabase.Auth.SignIn(email, password);
                if (response == null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}