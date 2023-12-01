using MainApp.Data;
using MainApp.Models;
using Microsoft.AspNetCore.Identity;

namespace MainApp.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(ApplicationDbContext _dbContext, UserManager<ApplicationUser> _userManager)
        {
            dbContext = _dbContext;
            userManager = _userManager;
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }



        public Task<IEnumerable<UserModel>> Get()
        {
            try
            {
                var xxx = dbContext.Users.ToList();


                var datas = from u in dbContext.Users
                            join ur in dbContext.UserRoles on u.Id equals ur.UserId
                            join r in dbContext.Roles on ur.RoleId equals r.Id
                            select new UserModel { UserName = u.UserName, Role = r.Name, UserId = u.Id, Nama = u.Name, Confirm = u.EmailConfirmed, Id = u.Id };
                return Task.FromResult(datas.AsEnumerable());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<UserModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> Post(UserModel model)
        {
            try
            {
                var user = new ApplicationUser { Name = model.Nama, UserName = model.UserName, Email = model.UserName, EmailConfirmed = true };
                var userResult = await userManager.CreateAsync(user, "Password@123");
                if (userResult.Succeeded) {
                   await userManager.AddToRoleAsync(user, model.Role);
                }

                model.Id = user.Id;
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> Put(string id, UserModel model)
        {
            var user = dbContext.Users.SingleOrDefault(x => x.Id == model.Id);
            if(user != null)
            {
                user.Name = model.Nama;
                user.UserName = model.UserName;
                user.Email= model.UserName;
                user.NormalizedEmail= model.UserName.ToUpper();
                user.NormalizedUserName= model.UserName.ToUpper();
                user.EmailConfirmed = model.Confirm;
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }

            return Task.FromResult(false);

        }
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
