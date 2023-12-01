using MainApp.Models;

namespace MainApp;

public interface IUserService
{
    Task<IEnumerable<UserModel>> Get();
    Task<UserModel> GetById(string id);
    Task<UserModel> Post(UserModel model);
    Task<bool> Put(string id, UserModel model);
    Task<bool> Delete(string id);
}
