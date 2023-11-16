namespace MainApp;

public interface IAkunService
{
    Task<IEnumerable<Akun>> Get();
    Task<Akun> GetById(int id);
    Task<Akun> Post(Akun model);
    Task<bool> Put(int id, Akun model);
    Task<bool> Delete(int id);
}
