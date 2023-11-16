
using System.Collections;
using System.Data.Common;
using MainApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MainApp;

public class KategoriService : IKategoriService
{
    private readonly ApplicationDbContext dbcontext;

    public KategoriService(ApplicationDbContext _dbcontext)
    {
        dbcontext = _dbcontext;
    }

    public Task<bool> Delete(int id)
    {
        try
        {
            var item = dbcontext.DataKategori.SingleOrDefault(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(item, "Data Tidak Ditemukan");
            dbcontext.DataKategori.Remove(item);
            dbcontext.SaveChanges();
            return Task.FromResult(true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<IEnumerable<Kategori>> Get()
    {
        try
        {
            var data = dbcontext.DataKategori.AsEnumerable();
            if (data == null)
                return Task.FromResult(Enumerable.Empty<Kategori>());
            else
                return Task.FromResult(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<Kategori> GetById(int id)
    {
        try
        {
            var data = dbcontext.DataKategori.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(result: data)!;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<Kategori> Post(Kategori model)
    {
        try
        {
            dbcontext.DataKategori.Add(model);
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

    public Task<bool> Put(int id, Kategori model)
    {
        try
        {
            var data = dbcontext.DataKategori.SingleOrDefault(x => x.Id == id);
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
