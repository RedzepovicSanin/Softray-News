using SoftrayNewsAPI.DL.DBContext;
using SoftrayNewsAPI.DL.Enums;
using SoftrayNewsAPI.DL.Models;
using SoftrayNewsAPI.Services;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using SoftrayNewsAPI.Utils;

namespace SoftrayNewsAPI.Services
{

    public class UserService : IUserService
    {
        private readonly dbContext dbContext;


        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin", Role = "Administrator", Status = UserStatus.Active, DateInserted = DateTime.Now },
            new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", Password = "user", Role ="Administrator", Status = UserStatus.Active, DateInserted = DateTime.Now }
        };
        public string Role { get; set; }
        public UserStatus Status { get; set; }
        public DateTime DateInserted { get; set; }
        public UserService(dbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<User> GetAllUsers()
        {
            try
            {
                List<User> users = _users.ToList();
                
                return users.WithoutPasswords().ToList();
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                User foundUser = await dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
                return foundUser.WithoutPassword();
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> InsertUser(User userForInsert)
        {
            try
            {
                User newUser = new User();
                newUser.FirstName = userForInsert.FirstName;
                newUser.LastName = userForInsert.LastName;
                newUser.Role = "Administrator";
                newUser.Status = 0;
                newUser.DateInserted = DateTime.Now;
                dbContext.User.Add(newUser);
                await dbContext.SaveChangesAsync();
                return newUser.WithoutPassword();
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> UpdateUser(User userForUpdate) {

            try
            {
                User updatedUser = dbContext.User.Where(x => x.Id == userForUpdate.Id).FirstOrDefault();
                if (updatedUser != null)
                {
                    updatedUser.FirstName = userForUpdate.FirstName;
                    updatedUser.LastName = userForUpdate.LastName;
                    updatedUser.Status = userForUpdate.Status;

                    dbContext.Update(updatedUser);
                    await dbContext.SaveChangesAsync();
                    return updatedUser.WithoutPassword();
                }
                else
                {
                    throw new Exception("User doesnt exist");
                }
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> DeleteUser(int id)
        {
            User foundUser = await dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            foundUser.Status = UserStatus.Inactive;

            dbContext.Update(foundUser);
            await dbContext.SaveChangesAsync();
            return foundUser.WithoutPassword();
        }

        public async Task<User> Authenticate(AuthModel model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            var secret = "this is my custom secret key int32 for authentication";
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Administrator", user.Id.ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }
    }
}