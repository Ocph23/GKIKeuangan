namespace MainApp;

public interface IKasService
{
    Task<IEnumerable<Kas>> Get();
    Task<Kas> GetById(int id);
    Task<IEnumerable<Kas>> GetByYear(int year);
    Task<Kas> Post(Kas model);
    Task<bool> Put(int id, Kas model);
    Task<bool> Delete(int id);
}
