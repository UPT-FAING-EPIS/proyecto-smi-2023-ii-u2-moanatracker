
using Moana.Models;

namespace Moana
{
    public interface IUserService
    {
        Task<User> GetUser(string email);
        Task<List<Paciente>> GetPatients();
        Task<Paciente> GetIdPaciente(int IdUser);
        Task<Medico> GetIdMedico(int IdUser);
        Task<(bool success, string errorMessage)> CreateUser(string email, string password, string name);
    }

    public class UserService : IUserService
    {
        private readonly Supabase.Client _supabase;

        public UserService(Supabase.Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _supabase
                   .From<User>()
                   .Select("id,name,rolid")
                   .Where(x => x.Email == email)
                   .Get();
            User usuario = user.Model;
            return usuario;
        }
        public async Task<Paciente> GetIdPaciente(int IdUser)
        {
            try
            {
                var patients = await _supabase
                    .From<Paciente>()
                    .Select("IdPaciente")
                    .Where(x => x.FkIdUsuario == IdUser)
                    .Get();
                return patients.Model;
            }
            catch
            {
                return new Paciente();
            }
        }
        public async Task<Medico> GetIdMedico(int IdUser)
        {
            try
            {
                var patients = await _supabase
                    .From<Medico>()
                    .Select("IdMedico")
                    .Where(x => x.FkIdUsuario == IdUser)
                    .Get();
                return patients.Model;
            }
            catch
            {
                return new Medico();
            }
        }
        public async Task<List<Paciente>> GetPatients()
        {
            try
            {
                var patients = await _supabase
                    .From<Paciente>()
                    .Select("*")
                    .Get();
                return patients.Models;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<User>> GetIdPaciente()
        {
            try
            {
                var patients = await _supabase
                    .From<User>()
                    .Select("name")
                    .Where(x => x.rolId == 4)
                    .Get();
                return patients.Models;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public async Task<(bool success, string errorMessage)> CreateUser(string email, string password, string name)
        {
            try
            {
                var user = new User
                {
                    Email = email,
                    Name = name,
                    Password = password,
                    Estado = 1,
                    Token = Guid.NewGuid().ToString(),
                    rolId = 4,
                    
                };
                var insertResult = await _supabase
                    .From<User>()
                    .Insert(user);

                if (insertResult.ResponseMessage.IsSuccessStatusCode)
                {
                    var session = await _supabase.Auth.SignUp(email, password);

                    if (session != null)
                    {
                        return (true, null);
                    }
                    else
                    {
                        await _supabase
                            .From<User>()
                            .Where(x => x.Email == email)
                            .Delete();
                        return (false, "Error al registrar al usuario en la autenticación de Supabase.");
                    }
                }
                else
                {
                    return (false, "Error en la inserción del usuario.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la creación de usuario: " + ex.Message);
                return (false, ex.Message);
            }
        }

    }
}