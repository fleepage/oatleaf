using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using fleepage.oatleaf.com.Helper;
using fleepage.oatleaf.com.Helper.Exceptions;
using fleepage.oatleaf.com.Queries.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.DataAccess.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _appSettings = appSettings.Value;

        }

        public async Task<User> Authenticate(AuthenticateDto dto)
        {
            if (string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Password))
                throw new EntityNotFoundException("Username or password is incorrect.");

            var user = await _context.Users
                .Include(u => u.Accounts)?.ThenInclude(a => a.Students)
                .Include(u => u.Accounts)?.ThenInclude(a => a.Parent)
                .Include(u => u.Accounts)?.ThenInclude(a => a.Teachers)
                .Include(u => u.Accounts)?.ThenInclude(a => a.Staffs)
                .Include(u => u.Accounts)?.ThenInclude(a => a.OrgAdmin)
                .Include(u => u.Accounts)?.ThenInclude(a => a.SchoolAdmin)
                .SingleOrDefaultAsync(x => x.Email == dto.Username || x.Phone == dto.Username || x.Username == dto.Username);

            // check if user exists
            if (user == null)
                throw new EntityNotFoundException("User does not exist.");

            //Check if user is confirmed
            if (!user.IsEmailConfirmed && !user.IsPhoneConfirmed)
                throw new AppException("Account is not confirmed.");

            //Check if user is active
            if (!user.IsActive)
                throw new AppException("Account is not active.");

            //Throttle request 
            if (user.LoginFailedDate != null)
            {
                var ts = DateTime.UtcNow - user.LoginFailedDate.GetValueOrDefault();
                var secondsPassed = ts.TotalSeconds;
                var isMaxCountExceeded = user.LoginFailedCount >= _appSettings.MaxLoginFailedCount;
                var isWaitingTimePassed = secondsPassed > _appSettings.LoginFailedWaitingTime;

                if (isMaxCountExceeded && !isWaitingTimePassed)
                {
                    var secondsToWait = _appSettings.LoginFailedWaitingTime - secondsPassed;
                    throw new AppException(string.Format(
                        "You must wait for {0} minutes before you try to log in again.", (int)(Math.Floor((double)(secondsToWait / 60)))));
                }
            }

            // check if password is correct
            if (!VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                user.LoginFailedCount += 1;
                user.LoginFailedDate = DateTime.UtcNow;
                _context.Update(user);
                await _context.SaveChangesAsync();
                throw new EntityNotFoundException("Username or password is incorrect.");
            }

            // authentication successful
            user.LoginFailedCount = 0;
            user.LoginFailedDate = null;
            user.LastLoginDate = DateTime.UtcNow;
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<CreateUserResponse> Register(User user, string password, string passwordConfirmation, string role)
        {
            if (string.IsNullOrWhiteSpace(password))
                return new CreateUserResponse { IsSuccess=false, Message= "Password is required" };

            if (!string.IsNullOrWhiteSpace(password) && (password != passwordConfirmation))
                return new CreateUserResponse { IsSuccess = false, Message = "Password and Confirm password do not match" }; 


            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Phone == user.Phone || x.Email == user.Email || x.Username == user.Username);

            if (existingUser?.Phone == user.Phone && role != "student")
                return new CreateUserResponse { IsSuccess = false, Message = string.Format("Phone '{0}' is already taken.", user.Phone) };

            if (existingUser?.Email == user.Email && role != "student" )
                return new CreateUserResponse { IsSuccess = false, Message = string.Format("Email '{0}' is already taken.", user.Email) }; 

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.CreatedDate = DateTime.UtcNow;
            user.EmailConfirmationCode = RandomGenerator.GenerateEmailCode(42);
            user.PhoneConfirmationCode = RandomGenerator.GeneratePhoneCode(6);

            //Comment out to force confirmation
            user.IsEmailConfirmed = true;
            user.IsPhoneConfirmed = true;
            user.PhoneConfirmedDate = DateTime.UtcNow;
            user.EmailConfirmedDate = DateTime.UtcNow;
            user.IsActive = true;
            //End

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            user.Username = user.FirstName + user.Id;
            await _context.SaveChangesAsync();



            return  new CreateUserResponse { IsSuccess = true, Message = "User created successfully", User = user}; 
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static void CreateUserName(string fname, string lname, DateTime dob, string old)
        {
            string suffix = string.Format("{0}{1}{2}",dob.Day,dob.Month);
        }

    }
        }
