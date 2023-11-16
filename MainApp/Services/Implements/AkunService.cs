
using System.Collections;
using System.Data.Common;
using MainApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MainApp;

public class AkunService : IAkunService
{
    private readonly ApplicationDbContext dbcontext;

    public AkunService(ApplicationDbContext _dbcontext)
    {
        dbcontext = _dbcontext;
    }

    public Task<bool> Delete(int id)
    {
        try
        {
            var item = dbcontext.DataAkun.SingleOrDefault(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(item, "Data Tidak Ditemukan");
            dbcontext.DataAkun.Remove(item);
            dbcontext.SaveChanges();
            return Task.FromResult(true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<IEnumerable<Akun>> Get()
    {
        try
        {
            var data = dbcontext.DataAkun.Include(x=>x.Kategori).AsEnumerable();
            if (data == null)
                return Task.FromResult(Enumerable.Empty<Akun>());
            else
                return Task.FromResult(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<Akun> GetById(int id)
    {
        try
        {
            var data = dbcontext.DataAkun.Include(x => x.Kategori).SingleOrDefault(x => x.Id == id);
            return Task.FromResult(result: data)!;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<Akun> Post(Akun model)
    {
        try
        {
            dbcontext.DataAkun.Add(model);
            dbcontext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (DbUpdateException ex)
        {
            if(ex.InnerException!=null && ex.InnerException.Message.Contains("duplicate key value"))
            {
                throw new Exception($"Kode : {model.Kode} Sudah Ada.");
            }
            throw;
        }
        catch (Exception){
            throw;
        }
    }

    public Task<bool> Put(int id, Akun model)
    {
        try
        {
            var data = dbcontext.DataAkun.SingleOrDefault(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data Tidak Ditemukan");
            dbcontext.Entry(data).CurrentValues.SetValues(model);
            dbcontext.SaveChanges();
            return Task.FromResult(true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
