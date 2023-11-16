namespace MainApp;

public interface IKategoriService
{
    Task<IEnumerable<Kategori>> Get();
    Task<Kategori> GetById(int id);
    Task<Kategori> Post(Kategori model);
    Task<bool> Put(int id, Kategori model);
    Task<bool> Delete(int id);
}
